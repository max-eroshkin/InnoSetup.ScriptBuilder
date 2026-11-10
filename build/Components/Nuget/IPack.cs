// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Linq;
using Fallout.Common;
using Fallout.Common.CI.GitLab;
using Fallout.Common.IO;
using Fallout.Common.Tooling;
using Fallout.Common.Tools.DotNet;
using static Fallout.Common.Tools.DotNet.DotNetTasks;

/// <summary>
/// Содержит команды для работы с nuget-пакетами.
/// </summary>
[PublicAPI]
public interface IPack : ICompile, IHazArtifacts
{
    /// <summary>
    /// Возвращает путь к папке для создаваемых пакетов.
    /// </summary>
    AbsolutePath PackagesDirectory => ArtifactsDirectory / "packages";

    /// <summary>
    /// Создает nuget-пакеты и помещает их в <see cref="PackagesDirectory"/>.
    /// </summary>
    Target Pack => _ => _
        .DependsOn(Compile)
        .TryAfter<ITest>()
        .Produces(PackagesDirectory / "*.nupkg")
        .Executes(() =>
        {
            DotNetPack(_ => _
                .Apply(PackSettingsBase)
                .Apply(PackSettings));

            if (PackagesDirectory.DirectoryExists())
            {
                foreach (var path in Directory.EnumerateFiles(PackagesDirectory, "*.nupkg"))
                    OverrideIcon(path);
            }
        });

    /// <summary>
    /// Возвращает базовые настройки для <see cref="Pack"/>.
    /// </summary>
    sealed Configure<DotNetPackSettings> PackSettingsBase
    {
        get
        {
            var properties = new Dictionary<string, object>
            {
                { "Copyright", $"Copyright {DateTime.UtcNow.Year} Platforma" },
                { "Authors", "Platforma" },
                { "Company", "Platforma" },
            };

            var gitlab = GitLab.Instance;
            if (gitlab != null)
            {
                properties.Add("PackageProjectUrl", gitlab.ProjectUrl);
                properties.Add("RepositoryBranch", gitlab.CommitRefName);
            }

            return _ => _
                .SetProject(Solution)
                .SetConfiguration(Configuration)
                .SetProperties(properties)
                .SetNoBuild(SucceededTargets.Contains(Compile))
                .SetOutputDirectory(PackagesDirectory)
                .When(
                    _ => ScheduledTargets.Any(x => x.Name == nameof(IPublish.PublishLocal)),
                    s => s.SetProperty("DebugType", "embedded"));
        }
    }

    /// <summary>
    /// Возвращает настройки для <see cref="Pack"/>.
    /// </summary>
    Configure<DotNetPackSettings> PackSettings => _ => _;

    /// <summary>
    /// Ставит стандартную иконку во nuget-пакете.
    /// </summary>
    /// <param name="path">Путь к пакету.</param>
    private void OverrideIcon(AbsolutePath path)
    {
        const string iconName = "icon.png";

        using (FileStream zipToOpen = new FileStream(path, FileMode.Open))
        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
        {
            var nuspecEntry = archive.Entries.First(x => x.Name.EndsWith(".nuspec", StringComparison.Ordinal));

            var doc = LoadNuspec(nuspecEntry);

            var ns = doc.Root!.Name.Namespace;
            var iconElement = doc.Root.Descendants(ns.GetName("icon")).FirstOrDefault();
            string? oldIcon = null;
            if (iconElement != null)
            {
                oldIcon = iconElement.Value;
                iconElement.SetValue(iconName);
            }
            else
            {
                var metadataElement = doc.Root.Descendants(ns.GetName("metadata")).FirstOrDefault();
                if (metadataElement == null)
                    return;
                metadataElement.Add(new XElement(ns.GetName("icon"), iconName));
            }

            ReplaceNuspec(nuspecEntry, doc);
            ReplaceIcon(oldIcon);

            XDocument LoadNuspec(ZipArchiveEntry entry)
            {
                using var stream = entry.Open();
                return XDocument.Load(stream);
            }

            void ReplaceNuspec(ZipArchiveEntry entry, XDocument document)
            {
                var nuspecEntryName = entry.Name;
                entry.Delete();
                entry = archive.CreateEntry(nuspecEntryName, CompressionLevel.Optimal);
                using var stream = entry.Open();
                document.Save(stream);
            }

            void ReplaceIcon(string? iconToReplace)
            {
                if (!string.IsNullOrEmpty(iconToReplace))
                    archive.Entries.First(x => x.Name == iconToReplace).Delete();

                var entry = archive.CreateEntry(iconName, CompressionLevel.Optimal);
                using var stream = entry.Open();

                var iconRes = typeof(IPack).Assembly
                    .GetManifestResourceNames()
                    .FirstOrDefault(x => x.EndsWith(iconName, StringComparison.Ordinal));

                if (iconRes == null)
                    return;

                using var iconStream = typeof(IPack).Assembly.GetManifestResourceStream(iconRes);

                if (iconStream == null)
                    return;

                iconStream.CopyTo(stream);
            }
        }
    }
}
