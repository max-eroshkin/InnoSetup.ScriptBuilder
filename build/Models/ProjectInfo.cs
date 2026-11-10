// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;

/// <summary>
/// Package Info.
/// </summary>
public class ProjectInfo
{
    /// <summary>
    /// Package Id.
    /// </summary>
    public string? PackageId { get; set; }

    /// <summary>
    /// Package Version.
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Corresponding menu item.
    /// </summary>
    public string? MenuItem { get; set; }

    /// <summary>
    /// Project name.
    /// </summary>
    public string? ProjectName { get; set; }

    /// <summary>
    /// Returns whether the package is published or not.
    /// </summary>
    public bool Published { get; set; }

    /// <summary>
    /// Project References.
    /// </summary>
    public IList<string>? ProjectReferences { get; set; }
}
