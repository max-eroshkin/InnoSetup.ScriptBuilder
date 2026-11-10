// Copyright (c) 2023-2026 Platforma. All rights reserved.

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1602

namespace Ci;

/// <summary>
/// Тип версии пакета.
/// </summary>
public enum VersionType
{
    Unknown = 0,
    Feature = 1,
    Develop = 2,
    ReleaseCandidate = 3,
    Release = 4,
}
