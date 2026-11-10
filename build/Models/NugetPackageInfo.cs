// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Text.Json.Serialization;

/// <summary>
/// Модель версии nuget-пакета.
/// </summary>
[PublicAPI]
#pragma warning disable MA0097, RCS1241
public record NugetPackageInfo : IComparable<NugetPackageInfo>
#pragma warning restore MA0097, RCS1241
{
    /// <summary>
    /// Модель версии nuget-пакета.
    /// </summary>
    /// <param name="name">Название пакета без версии.</param>
    /// <param name="version">Текстовое представление версии.</param>
    /// <param name="createdAt">Дата создания.</param>
    public NugetPackageInfo(
        string? name,
        string version,
        DateTime createdAt)
    {
        Name = name;
        Version = version;
        CreatedAt = createdAt;

        var group = Name;
        if (!string.IsNullOrEmpty(version))
        {
            var (grp, suffix) = PackageVersionUtility.ParseVersion(version);
            group += grp;
            Suffix = suffix;

            VersionComponents = PackageVersionUtility.GetVersionComponents(version);

            VersionType = PackageVersionUtility.GetVersionType(version);
            IsCalVer = VersionComponents is { Major: > 2000 };
        }

        Group = group;
    }

    /// <summary>
    /// Id пакета в nuget-узле.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Текстовое представление версии.
    /// </summary>
    public string Version { get; }

    /// <summary>
    /// Тип версии пакета.
    /// </summary>
    public VersionType VersionType { get; }

    /// <summary>
    /// Модель числовой части версии пакета.
    /// </summary>
    public NumericVersion? VersionComponents { get; }

    /// <summary>
    /// Версия по CalVer.
    /// </summary>
    public bool IsCalVer { get; }

    /// <summary>
    /// Часть версии без числового суффикса.
    /// </summary>
    public string? Group { get; }

    /// <summary>
    /// Чиловой суффикс версии.
    /// </summary>
    public int Suffix { get; }

    /// <summary>
    /// Название пакета без версии.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Дата создания.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }

    /// <inheritdoc />
    public int CompareTo(NugetPackageInfo? other)
    {
        if (!Name!.Equals(other!.Name, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new ArgumentException(
                $"Package name mismatch, expected {Name} but found {other.Name}.",
                nameof(other));
        }

        if (Group == other.Group)
            return Suffix.CompareTo(other.Suffix);

        var versionComparison = VersionComponents!.CompareTo(other.VersionComponents);

        if (versionComparison != 0)
            return versionComparison;

        return VersionType.CompareTo(other.VersionType);
    }
}
