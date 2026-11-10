// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// Содержит методы работы с версиями пакетов.
/// </summary>
public static class PackageVersionUtility
{
    private static readonly Regex VersionRegex = new(@"^(.+\D)(\d+)$");
    private static readonly Regex ReleaseRegex = new(@"^\d+(\.\d+)*$");
    private static readonly Regex ReleaseCandidateRegex = new(@"rc\d*$");
    private static readonly Regex DevelopRegex = new(@"dev\d*$");
    private static readonly Regex FeatureRegex = new("(feature|alpha)");
    private static readonly Regex ComponentRegex = new(@"^(\d+)\.(\d+)\.(\d+)");

    /// <summary>
    /// Извлекает из версии числовой суффикс и остальную часть версии.
    /// </summary>
    /// <param name="version">Версия пакета.</param>
    public static (string Group, int Suffix) ParseVersion(string version)
    {
        var versionMatch = VersionRegex.Match(version);
        if (versionMatch.Success)
        {
            var group = versionMatch.Groups[1].Value;
            var suffix = int.Parse(versionMatch.Groups[2].Value);

            return (group, suffix);
        }

        return (version, 0);
    }

    /// <summary>
    /// Определяет тип пакета по версии.
    /// </summary>
    /// <param name="version">Версия пакета.</param>
    public static VersionType GetVersionType(string version)
    {
        if (ReleaseRegex.IsMatch(version))
            return VersionType.Release;
        if (ReleaseCandidateRegex.IsMatch(version))
            return VersionType.ReleaseCandidate;
        if (DevelopRegex.IsMatch(version))
            return VersionType.Develop;
        if (FeatureRegex.IsMatch(version))
            return VersionType.Feature;
        return VersionType.Unknown;
    }

    /// <summary>
    /// Извлекает числовую часть версии пакета.
    /// </summary>
    /// <param name="version">Версия пакета.</param>
    public static NumericVersion? GetVersionComponents(string? version)
    {
        if (string.IsNullOrWhiteSpace(version))
            return null;

        var match = ComponentRegex.Match(version);
        if (!match.Success)
            return null;

        return new(
            int.Parse(match.Groups[1].Value),
            int.Parse(match.Groups[2].Value),
            int.Parse(match.Groups[3].Value));
    }

    /// <summary>
    /// Возвращает следующую очередную версию пакета, на основе предыдущей.
    /// </summary>
    /// <param name="currentVersion">Текущая версия пакета.</param>
    /// <param name="publishedTags">Список опубликованных версий.</param>
    public static string GetNextVersion(string currentVersion, IList<string>? publishedTags = null)
    {
        var exp = new Regex(@"(\d+)$");

        var match = exp.Match(currentVersion);

        if (!match.Success)
            throw new ArgumentException($"{currentVersion} - имеет неправильный формат версии", nameof(currentVersion));

        var nextVersion = exp.Replace(
            currentVersion,
            m =>
            {
                var current = m.Groups[1].Value;
                var nextVer = int.Parse(current) + 1;
                return nextVer.ToString(new string('0', current.Length));
            });

        if (publishedTags?.Contains(nextVersion) ?? false)
        {
            return GetNextVersion(nextVersion, publishedTags);
        }

        return nextVersion;
    }

    /// <summary>
    /// Возвращает следующую очередную версию пакета, на основе предыдущей.
    /// </summary>
    /// <param name="currentVersion">Текущая версия пакета.</param>
    /// <param name="mode">Режим инкремента.</param>
    /// <param name="publishedTags">Список опубликованных версий.</param>
    public static string GetNextVersion(string currentVersion, int mode, IList<string>? publishedTags = null)
    {
        var exp = new Regex(@"(\d+)$");

        var match = exp.Match(currentVersion);

        if (!match.Success)
            throw new ArgumentException($"{currentVersion} - имеет неправильный формат версии", nameof(currentVersion));

        var nextVersion = exp.Replace(
            currentVersion,
            m =>
            {
                var current = m.Groups[1].Value;
                var nextVer = int.Parse(current) + 1;
                return nextVer.ToString(new string('0', current.Length));
            });

        if (publishedTags?.Contains(nextVersion) ?? false)
        {
            return GetNextVersion(nextVersion, mode, publishedTags);
        }

        return nextVersion;
    }
}
