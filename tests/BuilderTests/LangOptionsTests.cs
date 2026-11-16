namespace BuilderTests
{
    using System.Collections.Generic;
    using InnoSetup.ScriptBuilder;

    public class LangOptionsTests : KeyValueSectionTestsBase<LangOptionsSection>
    {
        protected override string SectionName => "LangOptions";

        protected override Dictionary<string, string> ReferenceData => new()
        {
            { "LanguageName", "LanguageName" },
            { "DialogFontName", "DialogFontName" },
            { "DialogFontSize", "1" },
            { "WelcomeFontName", "WelcomeFontName" },
            { "WelcomeFontSize", "2" },
            { "TitleFontName", "TitleFontName" },
            { "TitleFontSize", "3" },
            { "CopyrightFontName", "CopyrightFontName" },
            { "CopyrightFontSize", "4" },
            { "RightToLeft", "yes" },
            { "LanguageID", "en-us" },
            { "LanguageCodePage", "1111" },
        };
    }
}