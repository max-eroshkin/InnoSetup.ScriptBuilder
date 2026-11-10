// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Fallout.Common.Git;
using Fallout.Common.Tooling;
using Fallout.Common.Utilities.Collections;
using Serilog;

public partial interface IPublish
{
#pragma warning disable

    private bool CheckIfLocalBranchBehindOrigin(string branchName)
    {
        var process = ProcessTasks.StartProcess("git", $"merge-base --is-ancestor origin/{branchName} {branchName}");
        process.WaitForExit();
        return process.ExitCode == 1;
    }

    /// <summary>
    /// Sets git tags for given packages.
    /// </summary>
    /// <param name="projects">Package list</param>
    /// <param name="release">Set release tag.</param>
    private void TagPackages(string[] projects, bool release = false)
    {
        IList<ProjectInfo>? publishProjects;

        if (release) //// RELEASE
        {
            publishProjects = GetProjectsByVersion(
                projects,
                @"\d+(\.\d+)*",
                "No release packages to publish found.");
        }
        else if (GitRepository.IsOnReleaseBranch() || GitRepository.IsOnHotfixBranch())
        {
            //// RELEASE CANDIDATE
            publishProjects = GetProjectsByVersion(
                projects,
                @"\d+(\.\d+)*-rc\d*",
                "No release candidate (-rc) packages to publish found.");
        }
        else //// DEVELOP
        {
            publishProjects = GetProjectsByVersion(
                projects,
                @"\d+(\.\d+)*-dev\d*",
                "No develop (-dev) packages to publish found.");
        }

        publishProjects.ForEach(project => PackageExtensions.TagPackage(Solution, GetPackageTag(project)));
    }

    /// <summary>
    /// Returns the package archive (nupkg) filenames corresponding to the tag values.
    /// </summary>
    /// <param name="tags">Tag values.</param>
    /// <remarks>Returns names only without '.nupkg' extension.</remarks>
    private IEnumerable<string> GetPackageFileNames(IEnumerable<string> tags)
    {
        return tags.Where(x => Regex.IsMatch(x, "^[^0-9]"));
    }

    /// <summary>
    /// Returns the tag value corresponding to the project info.
    /// </summary>
    /// <param name="projectInfo">Project info.</param>
    private string GetPackageTag(ProjectInfo projectInfo)
    {
        return $"{projectInfo.PackageId}.{projectInfo.Version}";
    }

    private static IEnumerable<string> ToSourceList(IEnumerable<string> output)
    {
        if (!output.Any())
            throw new ArgumentException("Не могу получить список источников", nameof(output));

        var enabledSources = output.Where(x => x.StartsWith('E')).ToArray();

        if (enabledSources.Length == 0)
            throw new InvalidOperationException("Все источники отключены");

        return enabledSources.Select(x => x.TrimStart('E', 'M', ' '));
    }

    private void PrintLastError()
    {
        if (!string.IsNullOrEmpty(PackableProjectInfoProvider.LastError))
            Log.Error("Не удалось получить информацию из регистра: {LastError}", PackableProjectInfoProvider.LastError);
    }
}
