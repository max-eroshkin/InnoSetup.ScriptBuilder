namespace BuilderTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using InnoSetup.ScriptBuilder.Model.RegistrySection;
    using Xunit;

    public class RegistryTests
    {
        [Fact]
        public void Entry()
        {
            var iss = new TestBuilder().ToString();

            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.First(x => x.Name == "Registry");

            var parameters = TestUtils.ParseParameters(section.Entries[0]);

            parameters.Should()
                .ContainAllKeys<RegistryEntry>()
                .And.BeEquivalentTo(new Dictionary<string, string>
                {
                    { "Root", "hkcu" },
                    { "Subkey", "\"Subkey\"" },
                    { "ValueName", "\"ValueName\"" },
                    { "ValueType", "string" },
                    { "ValueData", "\"ValueData\"" },
                    { "Components", "\"Components\"" },
                    { "Tasks", "\"Tasks\"" },
                    { "Languages", "\"Languages\"" },
                    { "MinVersion", "\"MinVersion\"" },
                    { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
                    { "Permissions", "service-full admins-modify" },
                    { "Flags", "createvalueifdoesntexist noerror" },
                });
        }

        [Fact]
        public void Section()
        {
            var iss = new TestBuilder().ToString();

            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.FirstOrDefault(x => x.Name == "Registry");
            section.Should().NotBeNull();
            var entryRegex = new Regex(TestUtils.ParameterSectionEntryPattern);
            section.Entries.Should()
                .HaveCount(2)
                .And.OnlyContain(x => entryRegex.IsMatch(x));
        }
    }
}