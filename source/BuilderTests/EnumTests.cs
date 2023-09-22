namespace BuilderTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using FluentAssertions;
    using InnoSetup.ScriptBuilder;
    using Xunit;

    public class EnumTests
    {
        [Theory]
        [MemberData(nameof(GetFlagEnums))]
        public void ValueDuplicationTest(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException($"{enumType.Name} is not an enum");
            
            var values = Enum
                .GetValues(enumType)
                .Cast<object>()
                .Select(x => new { Value = Enum.Format(enumType, x, "D"), EnumValue = x })
                .GroupBy(x => x.Value)
                .Where(x => x.Count() > 1)
                .ToList();

            values.Should().BeEmpty();
        }

        public static IEnumerable<object[]> GetFlagEnums()
        {
            return typeof(Architectures).Assembly.GetTypes()
                .Where(x => x.IsEnum && x.GetCustomAttribute<FlagsAttribute>() != null)
                .Select(x => new object[] { x });
        }
    }
}