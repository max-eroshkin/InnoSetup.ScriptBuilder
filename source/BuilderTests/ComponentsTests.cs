namespace BuilderTests
{
    using System.Collections.Generic;
    using InnoSetup.ScriptBuilder.Model.ComponentSection;

    public class ComponentsTests : ParameterSectionTestsBase<ComponentEntry>
    {
        protected override string SectionName => "Components";

        protected override Dictionary<string, string> ReferenceData => new()
        {
            { "Name", "\"Name\"" },
            { "Description", "\"Description\"" },
            { "ExtraDiskSpaceRequired", "123456" },
            { "Types", "\"Types\"" },
            { "Languages", "\"Languages\"" },
            { "MinVersion", "\"MinVersion\"" },
            { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
            { "Flags", "fixed exclusive" },
        };
    }
}