namespace BuilderTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using InnoSetup.ScriptBuilder.Model.DirsSection;
    using Xunit;

    public class DirsSectionTests
    {
        [Fact]
        public void Entry()
        {
            var iss = new TestBuilder().ToString();

            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.First(x => x.Name == "Dirs");

            var parameters = TestUtils.ParseParameters(section.Entries[0]);

            parameters.Should()
                .ContainAllKeys<DirEntry>()
                .And.BeEquivalentTo(new Dictionary<string, string>
                {
                    { "Name", "\"Name\"" },
                    { "Components", "\"Components\"" },
                    { "Tasks", "\"Tasks\"" },
                    { "Languages", "\"Languages\"" },
                    { "MinVersion", "\"MinVersion\"" },
                    { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
                    { "Permissions", "service-full admins-modify" },
                    { "Flags", "uninsalwaysuninstall" },
                    { "Attribs", "hidden system" },
                });
        }

        [Fact]
        public void Section()
        {
            var iss = new TestBuilder().ToString();

            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.FirstOrDefault(x => x.Name == "Dirs");
            section.Should().NotBeNull();
            var entryRegex = new Regex(TestUtils.ParameterSectionEntryPattern);
            section.Entries.Should()
                .HaveCount(2)
                .And.OnlyContain(x => entryRegex.IsMatch(x));
        }
    }
}