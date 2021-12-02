namespace BuilderTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using InnoSetup.ScriptBuilder.Model.DeleteSection;
    using Xunit;

    public class DeleteTests : ParameterSectionTestsBase<DeleteEntry>
    {
        protected override string SectionName => "UninstallDelete";

        protected override Dictionary<string, string> ReferenceData => new()
        {
            { "Name", "\"Name\"" },
            { "Type", "files" },
            { "Components", "\"Components\"" },
            { "Tasks", "\"Tasks\"" },
            { "Languages", "\"Languages\"" },
            { "MinVersion", "\"MinVersion\"" },
            { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
        };
        
        [Fact]
        public void InstallDeleteSection()
        {
            var iss = new TestBuilder().ToString();

            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.FirstOrDefault(x => x.Name == "InstallDelete");
            section.Should().NotBeNull();
            var entryRegex = new Regex(TestUtils.ParameterSectionEntryPattern);
            section.Entries.Should()
                .HaveCount(1)
                .And.OnlyContain(x => entryRegex.IsMatch(x));
        }
    }
}