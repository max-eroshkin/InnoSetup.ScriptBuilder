// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

/// <summary>
/// Модель числовой части версии пакета.
/// </summary>
/// <param name="Year">Первое число.</param>
/// <param name="Major">Второе число.</param>
/// <param name="Minor">Третье число.</param>
#pragma warning disable MA0097
public record NumericVersion(int Year, int Major, int Minor) : IComparable<NumericVersion>, IComparable
#pragma warning restore MA0097
{
    /// <inheritdoc />
    public int CompareTo(NumericVersion? other)
    {
        if (ReferenceEquals(this, other))
            return 0;

        if (other is null)
            return 1;

        var majorComparison = Year.CompareTo(other.Year);
        if (majorComparison != 0)
            return majorComparison;

        var minorComparison = Major.CompareTo(other.Major);
        if (minorComparison != 0)
            return minorComparison;

        return Minor.CompareTo(other.Minor);
    }

    /// <inheritdoc />
    public override string ToString() => $"{Year}.{Major}.{Minor}";

    /// <inheritdoc />
    public int CompareTo(object? obj)
    {
        if (obj == null)
        {
            return 1;
        }

        if (obj is NumericVersion x)
        {
            return CompareTo(x);
        }

        throw new ArgumentException("", nameof(obj));
    }
}
