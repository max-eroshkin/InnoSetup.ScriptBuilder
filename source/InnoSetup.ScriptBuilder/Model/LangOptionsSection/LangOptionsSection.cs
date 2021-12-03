namespace InnoSetup.ScriptBuilder.Model.LangOptionsSection
{
    public class LangOptionsSection : KeyValueSection
    {
        public string LanguageName { get; set; }

        public string DialogFontName { get; set; }

        public int? DialogFontSize { get; set; }

        public string WelcomeFontName { get; set; }

        public int? WelcomeFontSize { get; set; }

        public string TitleFontName { get; set; }

        public int? TitleFontSize { get; set; }

        public string CopyrightFontName { get; set; }

        public int? CopyrightFontSize { get; set; }

        public YesNo? RightToLeft { get; set; }

        public string LanguageID { get; set; }

        public long? LanguageCodePage { get; set; }
    }
}