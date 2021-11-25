namespace BuilderTests
{
    using System.Collections.Generic;
    using InnoSetup.ScriptBuilder.Model.LanguageSection;

    public class LanguagesTests : ParameterSectionTestsBase<LanguageEntry>
    {
        protected override string SectionName => "Languages";

        protected override Dictionary<string, string> ReferenceData => new()
        {
            { "Name", "\"Name\"" },
            { "MessagesFile", "\"MessagesFile\"" },
            { "LicenseFile", "\"LicenseFile\"" },
            { "InfoAfterFile", "\"InfoAfterFile\"" },
            { "InfoBeforeFile", "\"InfoBeforeFile\"" },
        };
    }
}