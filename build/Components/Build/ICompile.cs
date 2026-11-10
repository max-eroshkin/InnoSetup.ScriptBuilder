// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;
using System.Linq;
using Fallout.Common;
using Fallout.Common.Tooling;
using Fallout.Common.Tools.DotNet;

/// <summary>
/// Содержит команду компиляции решения.
/// </summary>
[PublicAPI]
public interface ICompile : IRestore, IHazConfiguration
{
    /// <summary>
    /// Компилирует решение.
    /// </summary>
    Target Compile => _ => _
        .DependsOn(Restore)
        .WhenSkipped(DependencyBehavior.Skip)
        .Executes(() =>
        {
            DotNetTasks.DotNetBuild(_ => _
                .Apply(CompileSettingsBase)
                .Apply(CompileSettings));
        });

    /// <summary>
    /// Базовые настройки для запуска <see cref="Compile"/>.
    /// </summary>
    sealed Configure<DotNetBuildSettings> CompileSettingsBase => _ => _
        .SetProjectFile(Solution)
        .SetConfiguration(Configuration)
        .SetProperties(
            new Dictionary<string, object>
            {
                { "Copyright", $"Copyright {DateTime.UtcNow.Year} Max Eroshkin" },
                { "Authors", "Max Eroshkin" }
            })
        .When(
            _ => IsServerBuild,
            s => s.EnableContinuousIntegrationBuild())
        .When(
            _ => ScheduledTargets.Any(x => x.Name == nameof(IPublish.PublishLocal)),
            s => s.SetProperty("DebugType", "embedded"))
        .SetNoRestore(SucceededTargets.Contains(Restore));

    /// <summary>
    /// Настройки для запуска <see cref="Compile"/>.
    /// </summary>
    Configure<DotNetBuildSettings> CompileSettings => _ => _;
}
