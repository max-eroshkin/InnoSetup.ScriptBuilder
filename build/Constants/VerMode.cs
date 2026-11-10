// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

/// <summary>
/// Режим версионирования.
/// </summary>
[PublicAPI]
public enum VerMode
{
#pragma warning disable  CS1591, SA1401, SA1600
    CalVer = 0,
    SemVer = 1
#pragma warning restore  CS1591, SA1401, SA1600
}
