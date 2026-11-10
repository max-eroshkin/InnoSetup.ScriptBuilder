// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Fallout.Common;

/// <summary>
/// Console Utility.
/// </summary>
public static class SelectionUtility
{
    private const ConsoleKey ConfirmationKey = ConsoleKey.Enter;
    private const ConsoleKey ToggleKey = ConsoleKey.Spacebar;
    private const ConsoleKey HeirarchyKey = ConsoleKey.M;
    private const ConsoleKey InterruptKey = ConsoleKey.F8;

    private static bool _interrupted;

    private static int BufferWidth => EnvironmentInfo.IsWin ? Console.BufferWidth - 1 : Console.BufferWidth;

    private const string Confirmed = "¬";

    private const string Selected = "»";
    private const string ReverseSelected = "«";

    private static string Checked => "x";

    private static string Unchecked => " ";

    private static string Unselected => " ";

    /// <summary>
    /// Prompts for options.
    /// </summary>
    /// <param name="question">A question.</param>
    /// <param name="firstOptionAsSelectAll">Use the first option as a 'Select All' option.</param>
    /// <param name="options">An option list.</param>
    /// <typeparam name="T">A value type.</typeparam>
    public static IList<T> PromptForOptions<T>(
        string question,
        bool firstOptionAsSelectAll,
        params (T Value, string Description)[] options)
    {
        var checks = new bool[options.Length];
        if (_interrupted)
            return options.Select(x => x.Value).Take(1).ToList();

        var selection = 0;
        ConsoleKey key;

        HostUtility.Information(question);
        do
        {
            for (var i = 0; i < options.Length; i++)
            {
                var (_, description) = options[i];
                var selected = i == selection;
                var prefix = selected ? Selected : Unselected;
                var postfix = selected ? ReverseSelected : Unselected;
                var checkMark = checks[i] ? Checked : Unchecked;
                var color = selected ? Color.DeepSkyBlue : Color.DarkGray;
                Console.WriteLine($"{prefix} {checkMark} {description} {postfix}", color);
            }

            key = Console.ReadKey(intercept: true).Key;
            if (key == ConsoleKey.UpArrow)
            {
                selection--;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selection++;
            }
            else if (key == InterruptKey)
            {
                _interrupted = true;
            }
            else if (key == ToggleKey || key == HeirarchyKey)
            {
                checks[selection] = !checks[selection];
                if (firstOptionAsSelectAll)
                {
                    if (selection == 0)
                    {
                        for (var i = 0; i < options.Length; i++)
                            checks[i] = checks[0];
                    }
                    else
                    {
                        checks[0] = checks.Skip(1).All(x => x);
                    }
                }
            }

            selection = Math.Max(val1: 0, Math.Min(options.Length - 1, selection));

            Console.CursorTop -= options.Length;
            for (var i = 0; i < options.Length; i++)
            {
                Console.WriteLine(new string(c: ' ', BufferWidth));
            }

            Console.CursorTop -= options.Length;
        }
        while (!(key == ConfirmationKey || key == InterruptKey));

        var result = new List<T>();
        var start = firstOptionAsSelectAll ? 1 : 0;
        for (var i = start; i < options.Length; i++)
        {
            if (checks[i])
            {
                Console.WriteLine($"{Confirmed}  {options[i].Description}", Color.Lime);
                result.Add(options[i].Value);
            }
        }

        return result;
    }

    /// <summary>
    /// Prompts for options.
    /// </summary>
    /// <param name="question">A question.</param>
    /// <param name="firstOptionAsSelectAll">Use the first option as a 'Select All' option.</param>
    /// <param name="options">An option list.</param>
    /// <typeparam name="T">A value type.</typeparam>
#pragma warning disable MA0051
    public static IList<T> PromptForHierarchyOptions<T>(
        string question,
        bool firstOptionAsSelectAll,
        params (T Value, string Description, IList<T> Refs)[] options)
    {
        var checks = new bool[options.Length];
        if (_interrupted)
            return options.Select(x => x.Value).Take(1).ToList();

        var selection = 0;
        ConsoleKey key;

        HostUtility.Information(question);
        do
        {
            for (var i = 0; i < options.Length; i++)
            {
                var (_, description, _) = options[i];
                var selected = i == selection;
                var prefix = selected ? Selected : Unselected;
                var postfix = selected ? ReverseSelected : Unselected;
                var checkMark = checks[i] ? Checked : Unchecked;
                var color = selected ? Color.DeepSkyBlue : Color.DarkGray;
                Console.WriteLine($"{prefix} {checkMark} {description} {postfix}", color);
            }

            key = Console.ReadKey(intercept: true).Key;
            if (key == ConsoleKey.UpArrow)
            {
                selection--;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selection++;
            }
            else if (key == InterruptKey)
            {
                _interrupted = true;
            }
            else if (key is ToggleKey or HeirarchyKey)
            {
                checks[selection] = !checks[selection];
                if (firstOptionAsSelectAll)
                {
                    if (selection == 0)
                    {
                        for (var i = 0; i < options.Length; i++)
                            checks[i] = checks[0];
                    }
                    else
                    {
                        checks[0] = checks.Skip(1).All(x => x);
                    }
                }

                if (key == HeirarchyKey)
                {
                    var dependants = options[selection].Refs;
                    if (dependants.Any())
                    {
                        for (var i = 0; i < options.Length; i++)
                        {
                            if (dependants.Contains(options[i].Value))
                                checks[i] = checks[selection];
                        }
                    }
                }
            }

            selection = Math.Max(val1: 0, Math.Min(options.Length - 1, selection));

            Console.CursorTop -= options.Length;
            for (var i = 0; i < options.Length; i++)
            {
                Console.WriteLine(new string(c: ' ', BufferWidth));
            }

            Console.CursorTop -= options.Length;
        }
        while (!(key == ConfirmationKey || key == InterruptKey));

        var result = new List<T>();
        var start = firstOptionAsSelectAll ? 1 : 0;
        for (var i = start; i < options.Length; i++)
        {
            if (checks[i])
            {
                Console.WriteLine($"{Confirmed}  {options[i].Description}", Color.Lime);
                result.Add(options[i].Value);
            }
        }

        return result;
    }
#pragma warning restore MA0051
}
