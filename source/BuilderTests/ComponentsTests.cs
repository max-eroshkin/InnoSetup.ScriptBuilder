namespace BuilderTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using InnoSetup.ScriptBuilder.Model.ComponentSection;
    using InnoSetup.ScriptBuilder.Model.FileSection;
    using InnoSetup.ScriptBuilder.Model.RegistrySection;
    using Xunit;

    public class ComponentsTests
    {
        [Fact]
        public void Section()
        {
            var iss = new TestBuilder().ToString();

            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.FirstOrDefault(x => x.Name == "Components");
            section.Should().NotBeNull();
            var entryRegex = new Regex(TestUtils.ParameterSectionEntryPattern);
            section.Entries.Should()
                .HaveCount(2)
                .And.OnlyContain(x => entryRegex.IsMatch(x));
        }

        [Fact]
        public void Entry()
        {
            var iss = new TestBuilder().ToString();

            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.First(x => x.Name == "Components");

            var parameters = TestUtils.ParseParameters(section.Entries[0]);

            parameters.Should()
                .ContainAllKeys<ComponentEntry>()
                .And.BeEquivalentTo(new Dictionary<string, string>
                {
                    { "Name", "\"Name\"" },
                    { "Description", "\"Description\"" },
                    { "ExtraDiskSpaceRequired", "123456" },
                    { "Types", "\"Types\"" },
                    { "Languages", "\"Languages\"" },
                    { "MinVersion", "\"MinVersion\"" },
                    { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
                    { "Flags", "fixed exclusive" },
                });
        }
    }
}