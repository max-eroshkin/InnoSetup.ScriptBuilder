namespace BuilderTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using InnoSetup.ScriptBuilder;
    using Xunit;

    public class RunSectionTests : ParameterSectionTestsBase<RunEntry>
    {
        protected override string SectionName => "Run";

        protected override Dictionary<string, string> ReferenceData => new()
        {
            { "Filename", "\"FileName\"" },
            { "Description", "\"Description\"" },
            { "Parameters", "\"Parameters\"" },
            { "WorkingDir", "\"WorkingDir\"" },
            { "StatusMsg", "\"StatusMsg\"" },
            { "RunOnceId", "\"RunOnceId\"" },
            { "Verb", "\"Verb\"" },
            { "Components", "\"Components\"" },
            { "Tasks", "\"Tasks\"" },
            { "Languages", "\"Languages\"" },
            { "MinVersion", "\"MinVersion\"" },
            { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
            { "Flags", "64bit runhidden" },
        };

        [Fact]
        public void UninstallRunSection()
        {
            var iss = new TestBuilder().ToString();

            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.FirstOrDefault(x => x.Name == "UninstallRun");
            section.Should().NotBeNull();
            var entryRegex = new Regex(TestUtils.ParameterSectionEntryPattern);
            section.Entries.Should()
                .HaveCount(1)
                .And.OnlyContain(x => entryRegex.IsMatch(x));
        }
    }
}