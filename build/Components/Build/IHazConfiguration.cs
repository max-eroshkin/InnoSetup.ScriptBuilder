// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using Fallout.Common;

/// <summary>
/// Содержит параметр <see cref="Configuration"/>.
/// </summary>
[PublicAPI]
public interface IHazConfiguration : IFalloutBuild
{
    /// <summary>
    /// Конфигурация сборки.
    /// </summary>
    [Parameter]
    Configuration Configuration => TryGetValue(() => Configuration) ??
                                   (IsLocalBuild ? Configuration.Debug : Configuration.Release);
}
