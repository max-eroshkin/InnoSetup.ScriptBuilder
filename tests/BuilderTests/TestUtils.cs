namespace BuilderTests
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using FluentAssertions.Collections;

    internal static class TestUtils
    {
        public const string ParameterSectionEntryPattern = @"^((\w+)\: ([^\;]+)\;\s?)+";
        public const string KeyValueSectionEntryPattern = @"^(\w+)\=(.+)$";
        private static readonly Regex SectionNamePattern = new(@"\[(\w+)\]");

        public static List<SectionInfo> GetSections(string iss)
        {
            var reader = new StringReader(iss);
            return GetSections(reader);
        }

        public static List<SectionInfo> GetSections(StringReader reader)
        {
            var sections = new List<SectionInfo>();
            var line = reader.ReadLine();
            while (line is not null)
            {
                var match = SectionNamePattern.Match(line);
                if (match.Success)
                {
                    var section = new SectionInfo
                    {
                        Name = match.Groups[1].Value,
                        Entries = new List<string>()
                    };
                    sections.Add(section);

                    line = reader.ReadLine();
                    while (line is not null && !SectionNamePattern.IsMatch(line))
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            section.Entries.Add(line);

                        line = reader.ReadLine();
                    }
                }
                else
                {
                    line = reader.ReadLine();
                }
            }

            return sections;
        }

        public static Dictionary<string, string> ParseParameters(string entry)
        {
            var parameterPattern = new Regex(@"(\w+)\: ([^\;]+)\;");
            var matches = parameterPattern.Matches(entry);
            Dictionary<string, string>
                dictionary = matches.ToDictionary(x => x.Groups[1].Value, x => x.Groups[2].Value);
            return dictionary;
        }
        
        public static KeyValuePair<string, string> ParseKeyValue(string entry)
        {
            var parameterPattern = new Regex(@"^(\w+)\=(.+)$");
            var x = parameterPattern.Match(entry);
            var result = new KeyValuePair<string, string>(x.Groups[1].Value, x.Groups[2].Value);
            return result;
        }

        public static AndConstraint<GenericDictionaryAssertions<IDictionary<string, string>, string, string>>
            ContainAllKeys<TEntry>(
                this GenericDictionaryAssertions<IDictionary<string, string>, string, string> should)
        {
            var properties = typeof(TEntry).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.Name).Where(x => x != "Aux").ToList();
            return should.ContainKeys(properties);
        }
    }

    [DebuggerDisplay("{Name}({Entries.Count})")]
    internal class SectionInfo
    {
        public string Name { get; set; }

        public List<string> Entries { get; set; }
    }
}