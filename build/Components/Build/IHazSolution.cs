// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using Fallout.Common;
using Fallout.Solutions;

/// <summary>
/// Содержит параметр <see cref="Solution"/>.
/// </summary>
[PublicAPI]
public interface IHazSolution : IFalloutBuild
{
    /// <summary>
    /// Информация о решении.
    /// </summary>
    [Solution]
    [Required]
    Solution Solution => TryGetValue(() => Solution) ?? throw new NullReferenceException("Solution not defined.");
}
