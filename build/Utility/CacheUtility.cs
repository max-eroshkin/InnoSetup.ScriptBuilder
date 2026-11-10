// Copyright (c) 2023-2026 Platforma. All rights reserved.

#nullable enable
namespace Ci;

using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Fallout.Common.Utilities;

/// <summary>
/// Value cache utility.
/// </summary>
internal static class CacheUtility
{
    private static readonly Dictionary<MemberInfo, object> SValueCache = [];

    /// <summary>
    /// Gets cached value.
    /// </summary>
    /// <param name="parameterExpression">Member selector.</param>
    /// <typeparam name="T">Member type.</typeparam>
    public static T? GetValue<T>(Expression<Func<T>> parameterExpression)
        where T : class
    {
        return TryGetValueWithCache<T>(parameterExpression);
    }

    /// <summary>
    /// Gets cached value.
    /// </summary>
    /// <param name="parameterExpression">Member selector.</param>
    /// <typeparam name="T">Member type.</typeparam>
    public static T? GetValue<T>(Expression<Func<object>> parameterExpression)
    {
        return TryGetValueWithCache<T>(parameterExpression);
    }

    /// <summary>
    /// Sets value.
    /// </summary>
    /// <param name="parameterExpression">Member selector.</param>
    /// <param name="value">Value.</param>
    public static void SetValue(Expression<Func<object>> parameterExpression, object value)
    {
        var parameter = parameterExpression.GetMemberInfo();
        SValueCache[parameter] = value;
    }

    private static T? TryGetValueWithCache<T>(LambdaExpression lambdaExpression)
    {
        var parameter = lambdaExpression.GetMemberInfo();
        return (T)SValueCache.GetValueOrDefault(parameter)!;
    }
}
