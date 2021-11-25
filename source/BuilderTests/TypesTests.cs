namespace BuilderTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using InnoSetup.ScriptBuilder.Model.ComponentSection;
    using InnoSetup.ScriptBuilder.Model.TypesSection;
    using Xunit;

    public class TypesTests
    {
        private const string SectionName = "Types";

        [Fact]
        public void Entry()
        {
            var iss = new TestBuilder().ToString();

            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.First(x => x.Name == SectionName);

            var parameters = TestUtils.ParseParameters(section.Entries[0]);

            parameters.Should()
                .ContainAllKeys<TypeEntry>()
                .And.BeEquivalentTo(new Dictionary<string, string>
                {
                    { "Name", "\"Name\"" },
                    { "Description", "\"Description\"" },
                    { "Flags", "iscustom" },
                    { "Languages", "\"Languages\"" },
                    { "MinVersion", "\"MinVersion\"" },
                    { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
                });
        }

        [Fact]
        public void Section()
        {
            var iss = new TestBuilder().ToString();

            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.FirstOrDefault(x => x.Name == SectionName);
            section.Should().NotBeNull();
            var entryRegex = new Regex(TestUtils.ParameterSectionEntryPattern);
            section.Entries.Should()
                .HaveCount(2)
                .And.OnlyContain(x => entryRegex.IsMatch(x));
        }
    }
}