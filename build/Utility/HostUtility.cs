// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Reflection;
using Fallout.Common;

/// <summary>
/// Содержит методы <see cref="Host"/>.
/// </summary>
public static class HostUtility
{
    private static readonly Type HostType = typeof(Host);
    private const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod;

    /// <summary>
    /// Выводит информационное сообщение.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public static void Information(string message)
    {
        HostType.InvokeMember("Information", Flags, null, null, [message]);
    }

    /// <summary>
    /// Выводит сообщение предупреждения.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public static void Warning(string message)
    {
        HostType.InvokeMember("Warning", Flags, null, null, [message]);
    }

    /// <summary>
    /// Выводит сообщение отладки.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public static void Debug(string message)
    {
        HostType.InvokeMember("Debug", Flags, null, null, [message]);
    }

    /// <summary>
    /// Выводит сообщение ошибки.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public static void Error(string message)
    {
        HostType.InvokeMember("Error", Flags, null, null, [message]);
    }

    /// <summary>
    /// Выводит сообщение.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public static void Verbose(string message)
    {
        HostType.InvokeMember("Verbose", Flags, null, null, [message]);
    }

    /// <summary>
    /// Выводит сообщение.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public static void Success(string message)
    {
        HostType.InvokeMember("Success", Flags, null, null, [message]);
    }
}
