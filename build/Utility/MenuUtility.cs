// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Threading;
using System.Threading.Tasks;
using Fallout.Common.Utilities.Collections;

internal static class MenuUtility
{
    public static async Task<int> NumMenu(
        string prompt,
        int? preselectedCommand,
        params (string title, Func<Task> action)[] commands)
    {
        if (commands.Length < 1 || commands.Length > 10)
            throw new ArgumentException("Поддерживается от 1 до 10 команд", nameof(commands));
        Console.Clear();
        HostUtility.Information(prompt);
        commands.ForEach((x, i) => Console.WriteLine($" [{i}] {x.title}"));
        Console.WriteLine(" [Q] Выход");

        var maxKey = ConsoleKey.D0 + commands.Length - 1;

        if (preselectedCommand != null && (preselectedCommand < 0 || preselectedCommand > commands.Length))
        {
            preselectedCommand = null;
        }

        var key = preselectedCommand == null
            ? Console.ReadKey(true).Key
            : ConsoleKey.D0 + preselectedCommand.Value;

        while (key != ConsoleKey.Q && (key < ConsoleKey.D0 || key > maxKey))
        {
            key = Console.ReadKey(true).Key;
        }

        if (key == ConsoleKey.Q)
            return -1;

        var commandIndex = key - ConsoleKey.D0;

        Console.Clear();
        HostUtility.Information($">> Выбрано [{commandIndex}] {commands[commandIndex].title}");

        await commands[commandIndex].action();
        return commandIndex;
    }

    public static async Task<ConsoleKeyInfo?> KeyToExit(Func<CancellationToken, Task> action)
    {
        using var cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;

        ConsoleKeyInfo? keyInfo = null;

        Task escapeTask = Task.Run(() =>
        {
            Console.WriteLine();
            HostUtility.Warning("Нажмите [Q] для остановки...");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);
                    cts.Cancel();
                    Console.WriteLine("\nОперация отменяется...");
                    break;
                }

                Thread.Sleep(100);
            }
        });

        try
        {
            await action(token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Операция прервана.");
        }
        finally
        {
            if (!escapeTask.IsCompleted)
            {
                await Task.WhenAny(escapeTask, Task.Delay(500));
            }
        }

        return keyInfo;
    }
}
