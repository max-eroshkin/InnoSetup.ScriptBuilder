// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;

/// <summary>
/// Компаратор для <see cref="VersionType"/>.
/// </summary>
public class VersionTypeComparer : IComparer<VersionType>, System.Collections.IComparer
{
    /// <summary>
    /// Экземпляр компаратора.
    /// </summary>
    public static VersionTypeComparer Instance { get; } = new();

    /// <inheritdoc />
    public int Compare(VersionType x, VersionType y)
    {
        if (x == y)
            return 0;

        if (x == VersionType.Release)
            return 1;

        if (y == VersionType.Release)
            return -1;

        if (x == VersionType.ReleaseCandidate)
            return 1;

        if (y == VersionType.ReleaseCandidate)
            return -1;

        return 0;
    }

    /// <inheritdoc />
    public int Compare(object? x, object? y)
    {
        if (x == y)
        {
            return 0;
        }

        if (x == null)
        {
            return -1;
        }

        if (y == null)
        {
            return 1;
        }

        if (x is VersionType a
            && y is VersionType b)
        {
            return Compare(a, b);
        }

        throw new ArgumentException("", nameof(x));
    }
}
