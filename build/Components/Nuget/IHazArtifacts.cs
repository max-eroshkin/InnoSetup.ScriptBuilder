// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using Fallout.Common;
using Fallout.Common.IO;

/// <summary>
/// Содержит параметр <see cref="ArtifactsDirectory"/>.
/// </summary>
[PublicAPI]
public interface IHazArtifacts : IFalloutBuild
{
    /// <summary>
    /// Возвращает путь к папке с артефактами.
    /// </summary>
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";
}
