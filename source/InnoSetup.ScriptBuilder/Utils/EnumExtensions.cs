using System;
using System.Reflection;
using System.Text;

namespace InnoSetup.ScriptBuilder
{
    public static class EnumExtensions
    {
        const string Separator = " ";

        public static string GetString(this Enum e)
        {
            return e.ToString("g").Replace(",", string.Empty).Replace("_", string.Empty).ToLower();
            /*if (e.GetType().GetCustomAttribute<FlagsAttribute>() is null)
            {
                return e.ToString().TrimStart('_').ToLower();
            }
            else
            {
                return e.FlagsEnumToString();
            }*/
        }

        private static string FlagsEnumToString(this Enum e)
        {
            var str = new StringBuilder();
            var enumType = e.GetType();

            foreach (object i in Enum.GetValues(enumType))
            {
                if (IsExactlyOneBitSet((int)i) && e.HasFlag((Enum)i))
                {
                    str.Append(i + Separator);
                }
            }

            if (str.Length > 0)
            {
                str.Length -= Separator.Length;
            }

            return str.ToString();
            
            static bool IsExactlyOneBitSet(int x) => x != 0 && (x & (x - 1)) == 0;
        }
    }
}