// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using Fallout.Common;
using Fallout.Common.Git;

/// <summary>
/// Содержит параметр <see cref="GitRepository"/>.
/// </summary>
[PublicAPI]
public interface IHazGitRepository : IFalloutBuild
{
    /// <summary>
    /// Возвращает информацию о git-репозитории.
    /// </summary>
    [GitRepository]
    [Required]
    GitRepository GitRepository => TryGetValue(() => GitRepository)
                                   ?? throw new ApplicationException("The Git repository isn't initialized.");
}
