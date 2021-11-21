namespace BuilderTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using InnoSetup.ScriptBuilder.Model.FileSection;
    using Xunit;

    public class FilesSectionTests
    {
        
        [Fact]
        public void Section()
        {
            var iss = new TestBuilder().ToString();
           
            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.FirstOrDefault(x => x.Name == "Files");
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
            var section = sections.First(x => x.Name == "Files");
            
            var parameters = TestUtils.ParseParameters(section.Entries[0]);
            
            parameters.Should()
                .ContainAllKeys<FileEntry>()
                .And.BeEquivalentTo(new Dictionary<string, string>
                {
                    { "Source", "\"Source\"" },
                    { "DestDir", "\"DestDir\"" },
                    { "DestName", "\"DestName\"" },
                    { "FontInstall", "\"FontInstall\"" },
                    { "Excludes", "\"Excludes\"" },
                    { "ExternalSize", "123456" },
                    { "StrongAssemblyName", "\"StrongAssemblyName\"" },
                    { "Components", "\"Components\"" },
                    { "Tasks", "\"Tasks\"" },
                    { "Languages", "\"Languages\"" },
                    { "MinVersion", "\"MinVersion\"" },
                    { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
                    { "Permissions", "service-full admins-modify" },
                    { "Flags", "sign" },
                    { "Attribs", "readonly system" },
                });
        }
    }
}