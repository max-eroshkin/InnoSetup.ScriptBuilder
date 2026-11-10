// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.IO;
using Fallout.Common.IO;
using Fallout.Solutions;
using Fallout.Common.Tooling;
using Fallout.Common.Tools.DotNet;
using Fallout.Common.Tools.Git;
using static Fallout.Common.Tools.DotNet.DotNetTasks;

/// <summary>
/// Содержит методы подготовки nuget-пакетов.
/// </summary>
public static class PackageExtensions
{
    /// <summary>
    /// Adds a git tag.
    /// </summary>
    /// <param name="solution">Solution.</param>
    /// <param name="tagValue">Tag value.</param>
    public static void TagPackage(Solution solution, string tagValue)
    {
        GitTasks.Git($"tag {tagValue}", solution.Directory);
    }

    /// <summary>
    /// Makes a package.
    /// </summary>
    /// <param name="solution">Solution.</param>
    /// <param name="project">Project.</param>
    /// <param name="outDir">Output directory.</param>
    /// <param name="configuration">Build configuration.</param>
    public static void PackPackage(
        Solution solution,
        ProjectInfo project,
        AbsolutePath outDir,
        string configuration)
    {
        var path = solution.GetProject(project.ProjectName)?.Path;
        DotNetPack(s => s
            .SetProject(path)
            .SetOutputDirectory(outDir)
            .SetConfiguration(configuration)
            .EnableNoBuild());
    }

    /// <summary>
    /// Makes a package.
    /// </summary>
    /// <param name="solution">Solution.</param>
    /// <param name="project">Project.</param>
    /// <param name="configurator">Build configuration.</param>
    public static void PackPackage(
        Solution solution,
        ProjectInfo project,
        Configure<DotNetPackSettings> configurator)
    {
        var path = solution.GetProject(project.ProjectName)?.Path;
        DotNetPack(config => configurator(config.SetProject(path)));
    }

    /// <summary>
    /// Pushes a package to nuget server.
    /// </summary>
    /// <param name="project">Project.</param>
    /// <param name="outDir">Output directory.</param>
    /// <param name="nugetApiKey">Nuget Api Key.</param>
    /// <param name="nugetSource">Nuget Source.</param>
    public static void PushPackage(
        ProjectInfo project,
        AbsolutePath outDir,
        string nugetApiKey,
        string nugetSource)
    {
        PushPackage(outDir, $"{project.PackageId}.{project.Version}", nugetApiKey, nugetSource);
    }

    /// <summary>
    /// Pushes a package to nuget server.
    /// </summary>
    /// <param name="outDir">Output directory.</param>
    /// <param name="package">Package name.</param>
    /// <param name="nugetApiKey">Nuget Api Key.</param>
    /// <param name="nugetSource">Nuget Source.</param>
    public static string PushPackage(
        AbsolutePath outDir,
        string package,
        string nugetApiKey,
        string? nugetSource)
    {
        var packagePath = Path.Combine(outDir, $"{package}.nupkg");
        DotNetNuGetPush(x => x
            .SetApiKey(nugetApiKey)
            .SetSource(nugetSource)
            .SetTargetPath(packagePath)
            .EnableSkipDuplicate());

        return package;
    }
}
