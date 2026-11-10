// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.ComponentModel;
using Fallout.Common.Tooling;

/// <summary>
/// Конфигурация сборки.
/// </summary>
[PublicAPI]
[TypeConverter(typeof(TypeConverter<Configuration>))]
public class Configuration : Enumeration
{
#pragma warning disable  CS1591, SA1401, SA1600
    public static readonly Configuration Debug = new() { Value = nameof(Debug) };
    public static readonly Configuration Release = new() { Value = nameof(Release) };

    public static implicit operator string(Configuration configuration)
    {
        return configuration.Value;
    }
#pragma warning restore  CS1591, SA1401, SA1600
}