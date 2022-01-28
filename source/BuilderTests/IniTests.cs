namespace BuilderTests
{
    using System.Collections.Generic;
    using InnoSetup.ScriptBuilder;

    public class IniTests: ParameterSectionTestsBase<IniEntry>
    {
        protected override string SectionName => "INI";

        protected override Dictionary<string, string> ReferenceData => new()
        {
            { "Filename", "\"Filename\"" },
            { "Section", "\"Section\"" },
            { "Key", "\"Key\"" },
            { "String", "\"String\"" },
            { "Flags", "createkeyifdoesntexist uninsdeleteentry" },
            { "Components", "\"Components\"" },
            { "Tasks", "\"Tasks\"" },
            { "Languages", "\"Languages\"" },
            { "MinVersion", "\"MinVersion\"" },
            { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
            { "Check", "\"Check\"" },
        };
    }
}