namespace BuilderTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using InnoSetup.ScriptBuilder.Model.LanguageSection;
    using Xunit;

    public class LanguagesTests
    {
        
        [Fact]
        public void Section()
        {
            var iss = new TestBuilder().ToString();
           
            iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(iss).ToList();
            var section = sections.FirstOrDefault(x => x.Name == "Languages");
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
            var section = sections.First(x => x.Name == "Languages");
            
            var parameters = TestUtils.ParseParameters(section.Entries[0]);
            
            parameters.Should()
                .ContainAllKeys<LanguageEntry>()
                .And.BeEquivalentTo(new Dictionary<string, string>
                {
                    { "Name", "\"Name\"" },
                    { "MessagesFile", "\"MessagesFile\"" },
                    { "LicenseFile", "\"LicenseFile\"" },
                    { "InfoAfterFile", "\"InfoAfterFile\"" },
                    { "InfoBeforeFile", "\"InfoBeforeFile\"" },
                });
        }
    }
}