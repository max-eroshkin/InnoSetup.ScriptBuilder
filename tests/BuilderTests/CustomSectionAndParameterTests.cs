namespace BuilderTests
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using InnoSetup.ScriptBuilder;
    using Xunit;

    public class CustomSectionAndParameterTests
    {
        [Fact]
        public void CustomKeyValueSection()
        {
            const string sectionName = "TestKeyValueSection";

            var script = GetScript(x =>
                x.Sections.CreateKeyValueSection(sectionName).CreateEntry()
                    .Parameter("param1", 1)
                    .Parameter("param2", "string parameter"));

            var sections = TestUtils.GetSections(script).ToList();
            var section = sections.FirstOrDefault(x => x.Name == sectionName);
            section.Should().NotBeNull();

            section!.Entries.Count.Should().Be(2);
        }

        [Theory]
        [InlineData("string", "string")]
        [InlineData(1, "1")]
        [InlineData(2U, "2")]
        [InlineData(3L, "3")]
        [InlineData(4UL, "4")]
        [InlineData(DirFlags.DeleteAfterInstall, "deleteafterinstall")]
        public void CustomKeyValueSectionParamter(object value, string scriptValue)
        {
            const string sectionName = "TestKeyValueSectionParameter";

            var script = GetScript(x =>
                x.Sections.CreateKeyValueSection(sectionName).CreateEntry()
                    .Parameter("param1", 1)
                    .Parameter("param2", value));

            var sections = TestUtils.GetSections(script).ToList();
            var section = sections.FirstOrDefault(x => x.Name == sectionName);
            section.Should().NotBeNull();

            section!.Entries.Last().Should().Be($"param2={scriptValue}");
        }

        [Fact]
        public void CustomParameterSection()
        {
            const string sectionName = "TestParameterSection";

            var script = GetScript(x =>
                x.Sections.CreateParameterSection(sectionName)
                    .CreateEntry().Parameter("param1", 1).Parameter("param2", "string parameter")
                    .CreateEntry().Parameter("param1", 2).Parameter("param2", "string parameter"));

            var sections = TestUtils.GetSections(script).ToList();
            var section = sections.FirstOrDefault(x => x.Name == sectionName);
            section.Should().NotBeNull();

            section!.Entries.Count.Should().Be(2);
        }

        [Theory]
        [InlineData("string parameter", "string parameter")]
        [InlineData(1, "1")]
        [InlineData(2U, "2")]
        [InlineData(3L, "3")]
        [InlineData(4UL, "4")]
        [InlineData(DirFlags.DeleteAfterInstall, "deleteafterinstall")]
        public void CustomParameterSectionParamter(object value, string scriptValue)
        {
            const string sectionName = "TestParameterSection";

            var script = GetScript(x =>
                x.Sections.CreateParameterSection(sectionName)
                    .CreateEntry().Parameter("param1", 1).Parameter("param2", value));

            var sections = TestUtils.GetSections(script).ToList();
            var section = sections.FirstOrDefault(x => x.Name == sectionName);
            section.Should().NotBeNull();

            section!.Entries.Last().Should().Be($"param1: 1; param2: {scriptValue}; ");
        }
        
        [Fact]
        public void KeyValueEmptyParameterValue()
        {
            const string sectionName = "TestKeyValueSection";

            var script = GetScript(x =>
                x.Sections.CreateKeyValueSection(sectionName).CreateEntry()
                    .Parameter("param1", null));

            var sections = TestUtils.GetSections(script).ToList();
            var section = sections.FirstOrDefault(x => x.Name == sectionName);
            section.Should().NotBeNull();

            section!.Entries.Should().BeEmpty();
        }
        
        [Fact]
        public void EmptyParameterValue()
        {
            const string sectionName = "TestParameterSection";

            var script = GetScript(x =>
                x.Sections.CreateParameterSection(sectionName)
                    .CreateEntry().Parameter("param1", null));

            var sections = TestUtils.GetSections(script).ToList();
            var section = sections.FirstOrDefault(x => x.Name == sectionName);
            section.Should().NotBeNull();

            section!.Entries.Should().BeEmpty();
        }

        private string GetScript(Action<IssBuilder> config)
        {
            var builder = BuilderUtils.CreateBuilder(config);
            return builder.ToString();
        }
    }
}