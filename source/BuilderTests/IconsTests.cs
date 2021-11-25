namespace BuilderTests
{
    using System.Collections.Generic;
    using InnoSetup.ScriptBuilder.Model.IconsSection;

    public class IconsTests : ParameterSectionTestsBase<IconEntry>
    {
        protected override string SectionName => "Icons";

        protected override Dictionary<string, string> ReferenceData => new()
        {
            { "Name", "\"Name\"" },
            { "Filename", "\"Filename\"" },
            { "Parameters", "\"Parameters\"" },
            { "WorkingDir", "\"WorkingDir\"" },
            { "HotKey", "\"HotKey\"" },
            { "Comment", "\"Comment\"" },
            { "IconFilename", "\"IconFilename\"" },
            { "IconIndex", "11" },
            { "AppUserModelID", "\"AppUserModelID\"" },
            { "AppUserModelToastActivatorCLSID", "\"AppUserModelToastActivatorCLSID\"" },
            { "Flags", "uninsneveruninstall closeonexit" },
            { "Components", "\"Components\"" },
            { "Tasks", "\"Tasks\"" },
            { "Languages", "\"Languages\"" },
            { "MinVersion", "\"MinVersion\"" },
            { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
        };
    }
}