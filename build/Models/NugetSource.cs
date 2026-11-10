// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

/// <summary>
/// Nuget source feed.
/// </summary>
/// <param name="Url">Url.</param>
/// <param name="ClientId">User name.</param>
/// <param name="Secret">API key|password.</param>
public record NugetSource(string Url, string? ClientId = null!, string? Secret = null!)
{
    /// <summary>
    /// Nuget Source.
    /// </summary>
    public static NugetSource Default { get; } =
        new("https://gitlab.platforma.build/api/v4/projects/15/packages/nuget/index.json");
}
