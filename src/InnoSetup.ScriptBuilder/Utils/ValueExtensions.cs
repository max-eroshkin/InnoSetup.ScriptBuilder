namespace InnoSetup.ScriptBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public static class ValueExtensions
    {
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
                _ => null
            };
        }

        public static string GetString(this Enum e)
        {
            return e.ToString("g").Replace(",", string.Empty).Replace("_", string.Empty).ToLower();
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
    }
}