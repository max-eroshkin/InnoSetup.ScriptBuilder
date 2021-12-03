namespace BuilderTests
{
    using System.Collections.Generic;
    using InnoSetup.ScriptBuilder;

    public class TypesTests : ParameterSectionTestsBase<TypeEntry>
    {
        protected override string SectionName => "Types";

        protected override Dictionary<string, string> ReferenceData => new()
        {
            { "Name", "\"Name\"" },
            { "Description", "\"Description\"" },
            { "Flags", "iscustom" },
            { "Languages", "\"Languages\"" },
            { "MinVersion", "\"MinVersion\"" },
            { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
        };
    }
}