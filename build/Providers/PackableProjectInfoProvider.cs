// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Fallout.Solutions;
using Serilog;

/// <summary>
/// Packable Project Info Provider.
/// </summary>
/// <remarks>
/// ctor.
/// </remarks>
internal sealed class PackableProjectInfoProvider
{
    private static PackableProjectInfoProvider? _instance;
    private readonly Lazy<Solution> _solution;
    private readonly GitlabDataProvider _gitlabDataProvider;
    private string[]? _selection;
    private List<ProjectInfo>? _projects;

    /// <summary>
    /// Package Info Provider.
    /// </summary>
    /// <remarks>
    /// ctor.
    /// </remarks>
    /// <param name="solution">Nuke Build instance.</param>
    /// <param name="nugetSource">Nuget source feed.</param>
    private PackableProjectInfoProvider(Func<Solution> solution, NugetSource nugetSource)
    {
        _gitlabDataProvider = new GitlabDataProvider(nugetSource);
        _solution = new Lazy<Solution>(solution);
    }

    /// <summary>
    /// The list of package projects in solution.
    /// </summary>
    public List<ProjectInfo> Projects
    {
        get => _projects ??= GetInfo();
        set => _projects = value;
    }

    /// <summary>
    /// Последняя ошибка при получении информации о пакете из регистра.
    /// </summary>
    public string? LastError { get; set; }

    /// <summary>
    /// Возвращает PackableProjectInfoProvider.
    /// </summary>
    /// <param name="solution">Nuke Build instance.</param>
    /// <param name="nugetSource">Nuget source feed.</param>
    public static PackableProjectInfoProvider GetInstance(Func<Solution> solution, NugetSource nugetSource)
    {
        return _instance ??= new PackableProjectInfoProvider(solution, nugetSource);
    }

    /// <summary>
    /// Сбрасывает кешированную информация о проектах.
    /// </summary>
    public void Reset() => _projects = null;

    /// <summary>
    /// Gets the selected item of project menu.
    /// </summary>
    public string[] GetSelectedMenuOption()
    {
        if (Projects.Count < 2)
            return Projects.Select(x => x.ProjectName!).ToArray();

        (string, string, IList<string>)[] options =
        [
            ("all", "Выбрать все", Array.Empty<string>()),
            .. Projects.OrderBy(x => x.PackageId).Select(x => (x.ProjectName!, x.MenuItem!, GetDependents(Projects, x.ProjectName!).ToList()))
        ];

        _selection =
            [.. SelectionUtility.PromptForHierarchyOptions("Выберите проекты используя стрелки и [ПРОБЕЛ]/[M]:", true, options)];

        return _selection;

        static IEnumerable<string> GetDependents(List<ProjectInfo> projects, string projectName)
        {
            var dependants = projects.Where(x => x.ProjectReferences?.Contains(projectName) == true).ToList();

            return dependants
                .Select(x => x.ProjectName!)
                .Concat(dependants.SelectMany(y => GetDependents(projects, y.ProjectName!)));
        }
    }

    /// <summary>
    /// Gets project list according the selected menu item.
    /// </summary>
    /// <param name="option">Selected menu item.</param>
    /// <param name="unpublished">Учитывать только неопубликованные.</param>
    public List<ProjectInfo> GetSelectedProjects(string[] option, bool unpublished = true)
    {
        var result = Projects
            .Where(x => (!x.Published || !unpublished) && MemoryExtensions.Contains(
                option,
                x.ProjectName,
                StringComparer.OrdinalIgnoreCase))
            .ToList();
        return result;
    }

    private List<ProjectInfo> GetInfo()
    {
        if (!_gitlabDataProvider.IsDefinedNugetSource)
        {
            Log.Warning(
                "Для получения данных о пакетах в nuget registry задайте параметры NugetSource, NugetUserName, NugetApiKey");
        }

        var result = _solution.Value.AllProjects.AsParallel()
            .Select(project =>
            {
                var info = GetPackageInfo(project);
                if (info == default)
                    return null;

                var item = new ProjectInfo
                {
                    ProjectName = project.Name,
                    PackageId = info.PackageId,
                    Version = info.Version,
                    Published = _gitlabDataProvider.CheckPackage(info.PackageId, info.Version),
                    ProjectReferences = project.GetMSBuildProject().Items
                        .Where(x => x.ItemType == "ProjectReference")
                        .Select(x => (project.Directory / x.EvaluatedInclude).NameWithoutExtension)
                        .ToList()
                };

                return item;
            })
            .Where(x => x != null)
            .Select(x => x!)
            .ToList();

        if (result.Count == 0)
            throw new OperationCanceledException("Solution does not contain any package information.");

        var maxLength = result.Max(x => x.PackageId!.Length + x.Version!.Length);

        result.ForEach(x => x.MenuItem =
            $"{x.PackageId} {x.Version} {new string(' ', maxLength - x.PackageId!.Length - x.Version!.Length)} {(x.Published ? "<published>" : "-----------")}");

        return [.. result.OrderBy(x => x.ProjectName)];
    }

    private (string PackageId, string Version) GetPackageInfo(Project project)
    {
        bool.TryParse(project.GetProperty("IsPackable"), out var isPackable);

        var packageId = project.GetProperty("PackageId");
        var version = project.GetProperty("Version");

        return !isPackable ? default : (packageId, version);
    }

    [PublicAPI]
    private record PackageInfo
    {
        public int Id { get; init; }

        public string? Version { get; init; }

        public string? Name { get; init; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; init; }
    }

    [PublicAPI]
    private record ErrorInfo(string Message);
}
