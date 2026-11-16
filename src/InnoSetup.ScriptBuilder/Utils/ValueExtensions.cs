namespace InnoSetup.ScriptBuilder;

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

public static class ValueExtensions
{
    private static readonly Dictionary<(Type Type, string MemberName), string> EnumValues = new();

    private static readonly object EnumValuesLock = new();

    private static readonly string[] FlagSeparator = [", "];

    public static string GetString(this object value, bool needQuotes = true)
    {
        return value switch
        {
            string str => GetString(str, needQuotes),
            Enum enumValue => GetString(enumValue),
            int number => number.ToString(NumberFormatInfo.InvariantInfo),
            uint number => number.ToString(NumberFormatInfo.InvariantInfo),
            long number => number.ToString(NumberFormatInfo.InvariantInfo),
            ulong number => number.ToString(NumberFormatInfo.InvariantInfo),
            List<GroupPermission> permissions => GetString(permissions),
            IssColor color => color.Value,
            IssYesNo flag => flag.Value,
            _ => null
        };
    }

    /// <summary>
    /// Converts an enum value to its Inno Setup representation.
    /// </summary>
    /// <remarks>
    /// Every member of a combined ([Flags]) value is translated separately: members marked with
    /// <see cref="IssValueAttribute"/> are written verbatim (for example <c>enhanced/nopassword</c>),
    /// while all other members are lowercased and have their underscores removed.
    /// See <see href="https://jrsoftware.org/inno-setup/documentation/?topic=setupsection">[Setup] section</see>.
    /// </remarks>
    /// <param name="e">The enum value to convert.</param>
    /// <returns>The generated script value; members of a combined value are separated by a space.</returns>
    public static string GetString(this Enum e)
    {
        var tokens = e.ToString("g").Split(FlagSeparator, StringSplitOptions.RemoveEmptyEntries);

        if (tokens.Length == 1)
            return GetEnumValue(e.GetType(), tokens[0]);

        return string.Join(" ", tokens.Select(x => GetEnumValue(e.GetType(), x)));
    }

    public static string GetString(this List<GroupPermission> value)
    {
        return string.Join(" ", value.Select(x => $"{x.Group.GetString()}-{x.Permission.GetString()}"));
    }

    public static string GetString(this string value, bool needQuotes = true)
    {
        if (needQuotes)
            return $"\"{value.Replace("\"", "\"\"")}\"";
        else
            return value;
    }

    private static string GetEnumValue(Type type, string memberName)
    {
        lock (EnumValuesLock)
        {
            if (EnumValues.TryGetValue((type, memberName), out var cached))
                return cached;
        }

        var value = ResolveEnumValue(type, memberName);

        lock (EnumValuesLock)
        {
            EnumValues[(type, memberName)] = value;
        }

        return value;
    }

    private static string ResolveEnumValue(Type type, string memberName)
    {
        var field = type.GetField(memberName, BindingFlags.Public | BindingFlags.Static);

        var attribute = field == null
            ? null
            : (IssValueAttribute)Attribute.GetCustomAttribute(field, typeof(IssValueAttribute), false);

        return attribute != null
            ? attribute.Value
            : memberName.Replace("_", string.Empty).ToLower();
    }
}