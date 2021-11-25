namespace BuilderTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using InnoSetup.ScriptBuilder.Model.RunSection;
    using Xunit;

    public class RunSectionTests
    {
        private const string SectionName = "Run";

        [Fact]
        public void Entry()
        {
            var iss = new TestBuilder().ToString();

            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.First(x => x.Name == SectionName);

            var parameters = TestUtils.ParseParameters(section.Entries[0]);

            parameters.Should()
                .ContainAllKeys<RunEntry>()
                .And.BeEquivalentTo(new Dictionary<string, string>
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
                });
        }

        [Fact]
        public void RunSection()
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