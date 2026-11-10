// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Linq;
using Fallout.Common;
using Fallout.Common.IO;
using Fallout.Common.Utilities.Collections;

/// <summary>
/// Содержит команды очистки решения.
/// </summary>
public interface IClean : IHazSolution
{
    /// <summary>
    /// Очищает папки в решении, заданные в <see cref="BaseCleanPaths"/> и <see cref="CleanPaths"/>.
    /// </summary>
    Target Clean => _ => _
        .Executes(() =>
        {
            Solution.Directory.GlobDirectories([.. BaseCleanPaths, .. CleanPaths])
                .Where(x => !BuildProjectDirectory.Contains(x))
                .ForEach(x => ((AbsolutePath)x).DeleteDirectory());
        });

    /// <summary>
    /// Базовый список путей для очистки.
    /// </summary>
    sealed string[] BaseCleanPaths =>
    [
        "**/bin",
        "**/obj",
        "output",
        "artifacts"
    ];

    /// <summary>
    /// Список путей для очистки.
    /// </summary>
    string[] CleanPaths => Array.Empty<string>();
}
