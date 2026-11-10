// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Fallout.Common;
using static Fallout.Common.Tools.Git.GitTasks;

/// <summary>
/// Содержит методы вычисления версии по репозиторию.
/// </summary>
public static class GitVersionUtility
{
    internal static readonly Regex BetaVersionRegex = new(@"^(\d\d\d\d)\.(\d+)\.(\d+)$");
    internal static readonly Regex ProductionVersionRegex = new(@"^(\d\d)\.(\d+)\.(\d+)$");

    private static readonly Func<int, int> BetaYearToVersion = x => x;
    private static readonly Func<int, int> ProductionYearToVersion = x => (x % 100);

    /// <summary>
    /// Возвращает номер сборки из наименования ветки.
    /// </summary>
    /// <param name="branch">Название ветки.</param>
    public static string? GetVersionFromBranch(string? branch)
    {
        if (string.IsNullOrEmpty(branch))
            return null;

        var regex = new Regex(@"(testing|release|hotfix|bugfix|prodfix)\/(?<version>.*)");
        if (!string.IsNullOrEmpty(branch) && regex.IsMatch(branch))
        {
            return regex.Match(branch).Groups["version"].Value;
        }

        return null;
    }

    /// <summary>
    /// Возвращает список с вариантами следующей beta-версии.
    /// </summary>
    public static IList<string> GetNextBetaVersions()
    {
        return GetNextVersions(
            BetaVersionRegex,
            BetaYearToVersion);
    }

    /// <summary>
    /// Возвращает список с вариантами следующей production-версии.
    /// </summary>
    public static IList<string> GetNextProductionVersions()
    {
        return GetNextVersions(
            ProductionVersionRegex,
            ProductionYearToVersion);
    }

    /// <summary>
    /// Возвращает список с вариантами следующей версии.
    /// </summary>
    /// <param name="tagPattern">Паттерн тегов.</param>
    /// <param name="yearToVersion">Преобразовывает гов в начальную часть версии.</param>
    private static IList<string> GetNextVersions(
        Regex tagPattern,
        Func<int, int> yearToVersion)
    {
        yearToVersion.NotNull();
        var result = new List<string>();

        Git("fetch --tags --force", logOutput: false, logInvocation: false);

        var commitTags = GetCommitTags();
        var isHotfix = commitTags != null;
        var versions = commitTags ?? GetRepositoryTags();

        var year = yearToVersion(DateTime.Now.Year);
        if (!versions.Any())
        {
            result.Add($"{yearToVersion(year)}.1.0");
            return result;
        }

        var max = versions.Max()!;

        if (year > max.Year)
            result.Add($"{year}.1.0");

        result.Add($"{max.Year}.{max.Major + 1}.0");

        if (isHotfix)
            result.Insert(0, $"{yearToVersion(max.Year)}.{max.Major}.{max.Minor + 1}");
        else
            result.Add($"{yearToVersion(max.Year)}.{max.Major}.{max.Minor + 1}");

        return result;

        List<NumericVersion> GetRepositoryTags()
        {
            // находимся на ветке develop
            return Git("tag -l", logOutput: false)
                .Select(x => x.Text)
                .Where(x => tagPattern.IsMatch(x))
                .Distinct()
                .Select<string, NumericVersion>(x =>
                {
                    var match = tagPattern.Match(x);
                    return new(
                        int.Parse(match.Groups[1].Value),
                        int.Parse(match.Groups[2].Value),
                        int.Parse(match.Groups[3].Value));
                })
                .ToList();
        }

        List<NumericVersion>? GetCommitTags()
        {
            // находимся на ветке master
            var tags = Git("tag --points-at HEAD")
                .Select(x => x.Text)
                .Where(x => tagPattern.IsMatch(x))
                .Distinct()
                .Select<string, NumericVersion>(x =>
                {
                    var match = tagPattern.Match(x);
                    return new(
                        int.Parse(match.Groups[1].Value),
                        int.Parse(match.Groups[2].Value),
                        int.Parse(match.Groups[3].Value));
                })
                .ToList();

            return tags.Any() ? tags : null;
        }
    }
}
