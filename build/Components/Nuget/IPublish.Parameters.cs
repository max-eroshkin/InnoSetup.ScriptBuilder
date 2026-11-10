// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Linq;
using Fallout.Common;
using Fallout.Common.Tools.DotNet;
using Fallout.Common.Utilities;

public partial interface IPublish
{
    /// <summary>
    /// The message for the release tag.
    /// </summary>
    [Parameter("The message for the release tag.")]
    string? ReleaseMessage => TryGetValue(() => ReleaseMessage);

    /// <summary>
    /// Паттерн feature-пакетов.
    /// </summary>
    [Parameter("Паттерн версии feature-пакетов.")]
    string FeatPackagePattern => TryGetValue(() => FeatPackagePattern) ?? @"^\d+\.\d+\.\d+(-feature-|-alpha-)";

    /// <summary>
    /// Паттерн dev-пакетов.
    /// </summary>
    [Parameter("Паттерн версии dev-пакетов.")]
    string DevPackagePattern => TryGetValue(() => DevPackagePattern) ?? @"^\d+\.\d+\.\d+-dev\d*$";

    /// <summary>
    /// Паттерн rc-пакетов.
    /// </summary>
    [Parameter("Паттерн версии rc-пакетов.")]
    string RcPackagePattern => TryGetValue(() => RcPackagePattern) ?? @"^\d+\.\d+\.\d+-rc\d*$";

    /// <summary>
    /// Паттерн rc-пакетов.
    /// </summary>
    [Parameter("Паттерн версии release-пакетов.")]
    string ReleasePackagePattern => TryGetValue(() => ReleasePackagePattern) ?? @"^\d+\.\d+\.\d+$";

    /// <summary>
    /// Локальный регистр пакетов.
    /// </summary>
    [Parameter(" Локальный регистр пакетов")]
    string? LocalSource
    {
        get
        {
            var result = TryGetValue(() => LocalSource) ?? CacheUtility.GetValue(() => LocalSource!);
            if (result != null)
                return result;

            var outputs = DotNetTasks.DotNet(
                "nuget list source --format Short",
                logOutput: false,
                logInvocation: false);

            var options = ToSourceList(outputs.Select(x => x.Text))
                .Where(x => !x.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            if (options.Length == 0)
                return result;

            result = options.Length == 1
                ? options[0]
                : ConsoleUtility.PromptForChoice(
                    "Выберите источник nuget-пакетов",
                    options.Select(x => (x, x)).ToArray());

            CacheUtility.SetValue(() => LocalSource!, result);

            return result;
        }

        set { CacheUtility.SetValue(() => LocalSource!, value!); }
    }

    /// <summary>
    /// Время паузы в секундах между запросами статуса публикации пакета.
    /// </summary>
    int DelayTime => 60;

    /// <summary>
    /// Таймаут при ожидании публикации пакета.
    /// </summary>
    TimeSpan Timeout => TimeSpan.FromMinutes(15);
}
