namespace BuilderTests
{
    using System.Collections.Generic;
    using InnoSetup.ScriptBuilder;

    public class FilesTests : ParameterSectionTestsBase<FileEntry>
    {
        protected override string SectionName => "Files";

        protected override Dictionary<string, string> ReferenceData => new()
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
        };
    }
}