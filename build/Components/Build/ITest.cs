// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using Fallout.Common;
using Fallout.Common.Tooling;
using Fallout.Common.Tools.DotNet;
using static Fallout.Common.Tools.DotNet.DotNetTasks;

/// <summary>
/// Содержит команду запуска тестов.
/// </summary>
[PublicAPI]
public interface ITest : ICompile
{
    /// <summary>
    /// Запускает все тесты решения.
    /// </summary>
    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest(settings => settings
                .Apply(BaseTestConfiguration)
                .Apply(TestConfiguration));
        });

    /// <summary>
    /// Базовые настройки для запуска <see cref="Test"/>.
    /// </summary>
    sealed Configure<DotNetTestSettings> BaseTestConfiguration => settings => settings
        .SetConfiguration(Configuration)
        .SetVerbosity(DotNetVerbosity.minimal)
        .SetNoBuild(SucceededTargets.Contains(Compile))
        .SetProjectFile(Solution);

    /// <summary>
    /// Настройки для запуска <see cref="Test"/>.
    /// </summary>
    Configure<DotNetTestSettings> TestConfiguration => _ => _;
}
