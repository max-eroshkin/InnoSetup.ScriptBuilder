namespace BuilderTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using Xunit;

    public abstract class ParameterSectionTestsBase<TModel>
    {
        private readonly string _iss;

        protected abstract string SectionName { get; }
        
        protected abstract Dictionary<string, string> ReferenceData { get; }

        protected ParameterSectionTestsBase()
        {
            _iss = new TestBuilder().ToString();
        }

        [Fact]
        public virtual void Section()
        {
            _iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(_iss).ToList();
            var section = sections.FirstOrDefault(x => x.Name == SectionName);
            section.Should().NotBeNull();
            var entryRegex = new Regex(TestUtils.ParameterSectionEntryPattern);
            section.Entries.Should()
                .HaveCount(2)
                .And.OnlyContain(x => entryRegex.IsMatch(x));
        }
        
        [Fact]
        public virtual void Entry()
        {
            _iss.Should().NotBeEmpty();
            var sections = TestUtils.GetSections(_iss).ToList();
            var section = sections.First(x => x.Name == SectionName);

            var parameters = TestUtils.ParseParameters(section.Entries[0]);

            parameters.Should()
                .ContainAllKeys<TModel>()
                .And.BeEquivalentTo(ReferenceData);
        }
    }
}