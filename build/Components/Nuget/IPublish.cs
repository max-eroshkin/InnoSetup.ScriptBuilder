// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Linq;
using Fallout.Common;
using Fallout.Common.Git;
using Fallout.Common.Tools.DotNet;
using Fallout.Common.Tools.Git;
using Fallout.Common.Utilities.Collections;
using Fallout.Solutions;
using Serilog;

/// <summary>
/// Содержит команды публикации nuget-пакетов.
/// </summary>
[PublicAPI]
public partial interface IPublish : IPack, IHazGitRepository, IHazPackages
{
    /// <summary>
    /// Опубликовывает пакеты, которые соответствуют тегам на текущем комите.
    /// </summary>
    Target Publish => _ => _
        .Description("Publishes packages based on the tags of the current commit.")
        .Requires(() => NugetApiKey, () => NugetSource)
        .DependsOn<IPack>(x => x.Pack)
        .Executes(() =>
        {
            if (GitRepository.Tags.Count == 0)
            {
                Log.Information("No tags, exit");
                return;
            }

            var packageNames = GetPackageFileNames(GitRepository.Tags);

            var published = packageNames
                .Select(x => PackageExtensions.PushPackage(PackagesDirectory, x, NugetApiKey!, NugetSource))
                .ToList();
        });

    /// <summary>
    /// Публикует пакеты в локальные регистры.
    /// </summary>
    Target PublishLocal => _ => _
        .DependsOn<IPack>(x => x.Pack)
        .Requires(() => Packages)
        .Requires(() => LocalSource)
        .Executes(() =>
        {
            var projects = GetProjectsByVersion(Packages, @"\w", "Не выбрано пакетов для публикации", false);
            projects.ForEach(project =>
            {
                DotNetTasks.DotNetNuGetPush(config => config
                    .SetSource(LocalSource)
                    .SetTargetPath(PackagesDirectory / $"{project.PackageId}.{project.Version}.nupkg")
                    .EnableSkipDuplicate());
            });
        });

    /// <summary>
    /// Создает в репозитории на текущем комите тэги, соответствующие создаваемым пакетам.
    /// </summary>
    Target Tag => _ => _
        .OnlyWhenDynamic(GitTasks.GitHasCleanWorkingCopy)
        .Requires(() => Packages)
        .DependsOn<ICompile>(x => x.Compile)
        .Executes(() =>
        {
            var pattern = "no pattern";

            if (GitRepository.IsOnFeatureBranch())
            {
                pattern = FeatPackagePattern;
            }
            else if (GitRepository.IsOnDevelopBranch())
            {
                pattern = DevPackagePattern;
            }
            else if (GitRepository.IsOnReleaseBranch() || GitRepository.IsOnHotfixBranch())
            {
                pattern = RcPackagePattern;
            }
            else if (GitRepository.IsOnMainOrMasterBranch())
            {
                pattern = ReleasePackagePattern;
            }
            else
            {
                throw new InvalidOperationException(
                    "Тег можно ставить на develop, feature/*, release/*, master ветках");
            }

            var publishProjects = GetProjectsByVersion(
                Packages,
                pattern,
                $"Не обнаружено пакетов для публикации, соответствующих паттерну {pattern}");

            publishProjects.ForEach(project => PackageExtensions.TagPackage(Solution, GetPackageTag(project)));

            PrintLastError();
        });

    /// <summary>
    /// Выводит в консоль перечень проектов для публикации пакетов.
    /// </summary>
    Target List => _ => _
        .Executes(
            () =>
            {
                if (Solution.AllProjects.All(x =>
                        !bool.TryParse(x.GetProperty("IsPackable"), out var isPackable) || !isPackable))
                {
                    HostUtility.Error("Solution does not contain any package information.");
                    return;
                }

                PackableProjectInfoProvider.Projects.ForEach(x => Console.WriteLine(x.MenuItem));
            },
            PrintLastError);
}
