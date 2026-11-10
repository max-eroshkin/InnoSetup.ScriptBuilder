// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Fallout.Common;

/// <summary>
/// Содержит параметр <see cref="Packages"/>.
/// </summary>
public interface IHazPackages : IHazSolution, IHazNugetSource
{
    /// <summary>
    /// Project name list.
    /// </summary>
    [Parameter("Project name list")]
    string[] Packages
    {
        get
        {
            var result = TryGetValue(() => Packages) ?? CacheUtility.GetValue(() => Packages);
            if (result != null)
                return result;

            result = AllPackages
                ? PackableProjectInfoProvider.Projects.Select(x => x.ProjectName!).ToArray()
                : PackableProjectInfoProvider.GetSelectedMenuOption();

            CacheUtility.SetValue(() => Packages, result);
            return result;
        }

        set { CacheUtility.SetValue(() => Packages, value); }
    }

    /// <summary>
    /// Выполнять для всех пакетов.
    /// </summary>
    [Parameter("All projects")]
    bool AllPackages => TryGetValue<bool?>(() => AllPackages) ?? false;

    /// <summary>
    /// Package Info Provider.
    /// </summary>
    internal PackableProjectInfoProvider PackableProjectInfoProvider => PackableProjectInfoProvider.GetInstance(
        () => Solution,
        string.IsNullOrEmpty(NugetSource)
            ? Ci.NugetSource.Default
            : new NugetSource(NugetSource, NugetUserName, NugetApiKey));

    /// <summary>
    /// Returns the projects whose version matches the specified pattern.
    /// </summary>
    /// <param name="projects">Project collection.</param>
    /// <param name="versionPattern">Version template pattern.</param>
    /// <param name="errorMsg">The exception message that is thrown if '<paramref name="projects"/>' does not contain any matching projects.</param>
    /// <param name="unpublished">Учитывать только неопубликованные.</param>
    /// <exception cref="InvalidOperationException">If '<paramref name="projects"/>' does not contain any matching projects.</exception>
    IList<ProjectInfo> GetProjectsByVersion(
        string[] projects,
        string versionPattern,
        string errorMsg,
        bool unpublished = true)
    {
        var packages = PackableProjectInfoProvider
            .GetSelectedProjects(projects, unpublished)
            .Where(x => x.Version is not null && Regex.IsMatch(x.Version, versionPattern))
            .ToList();

        if (packages.Count == 0)
            throw new InvalidOperationException(errorMsg);

        return packages;
    }
}
