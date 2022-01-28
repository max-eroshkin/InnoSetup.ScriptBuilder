namespace BuilderTests
{
    using System.Collections.Generic;
    using InnoSetup.ScriptBuilder;

    public class DirsTests : ParameterSectionTestsBase<DirEntry>
    {
        protected override string SectionName => "Dirs";

        protected override Dictionary<string, string> ReferenceData => new()
        {
            { "Name", "\"Name\"" },
            { "Components", "\"Components\"" },
            { "Tasks", "\"Tasks\"" },
            { "Languages", "\"Languages\"" },
            { "MinVersion", "\"MinVersion\"" },
            { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
            { "Permissions", "service-full admins-modify" },
            { "Flags", "uninsalwaysuninstall" },
            { "Attribs", "hidden system" },
            { "Check", "\"Check\"" },
        };
    }
}