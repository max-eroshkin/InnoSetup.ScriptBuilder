// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using Fallout.Common;

/// <summary>
/// Содержит параметры доступа к API реестра пакетов.
/// </summary>
public interface IHazNugetSource : IFalloutBuild
{
    /// <summary>
    /// NuGet source URL.
    /// </summary>
    [Parameter("NuGet source URL")]
    string? NugetSource => TryGetValue(() => NugetSource) ??
                           "https://gitlab.platforma.build/api/v4/projects/15/packages/nuget/index.json";

    /// <summary>
    /// Nuget API key.
    /// </summary>
    [Parameter("Nuget API username")]
    [Secret]
    string? NugetUserName => TryGetValue(() => NugetUserName);

    /// <summary>
    /// Nuget API key.
    /// </summary>
    [Parameter("Nuget API key")]
    [Secret]
    string? NugetApiKey => TryGetValue(() => NugetApiKey);
}
