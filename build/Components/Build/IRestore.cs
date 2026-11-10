// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using Fallout.Common;
using Fallout.Common.Tooling;
using Fallout.Common.Tools.DotNet;
using static Fallout.Common.Tools.DotNet.DotNetTasks;

/// <summary>
/// Содержит команды для восстановления зависимостей.
/// </summary>
[PublicAPI]
public interface IRestore : IClean
{
    /// <summary>
    /// Восстанавливает зависимости в решении.
    /// </summary>
    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(_ => _
                .Apply(RestoreSettingsBase)
                .Apply(RestoreSettings));
        });

    /// <summary>
    /// Возвращает базовые настройки для <see cref="Restore"/>.
    /// </summary>
    sealed Configure<DotNetRestoreSettings> RestoreSettingsBase => _ => _
        .SetProjectFile(Solution)
        .SetIgnoreFailedSources(IgnoreFailedSources);

    /// <summary>
    /// Возвращает настройки для <see cref="Restore"/>.
    /// </summary>
    Configure<DotNetRestoreSettings> RestoreSettings => _ => _;

    /// <summary>
    /// Игнорировать недоступные источники пакетов во время <see cref="Restore"/>.
    /// </summary>
    [Parameter("Игнорировать недоступные источники пакетов во время " + nameof(Restore))]
    bool IgnoreFailedSources => TryGetValue<bool?>(() => IgnoreFailedSources) ?? false;
}
