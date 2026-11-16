namespace InnoSetup.ScriptBuilder
{
    using System;

    public class LangOptionsSection : KeyValueSection
    {
        public string LanguageName { get; set; }

        public string DialogFontName { get; set; }

        public int? DialogFontSize { get; set; }

        public string WelcomeFontName { get; set; }

        public int? WelcomeFontSize { get; set; }

        [Obsolete("Removed in Inno Setup 6.4")]
        public string TitleFontName { get; set; }

        [Obsolete("Removed in Inno Setup 6.4")]
        public int? TitleFontSize { get; set; }

        [Obsolete("Removed in Inno Setup 6.4")]
        public string CopyrightFontName { get; set; }

        [Obsolete("Removed in Inno Setup 6.4")]
        public int? CopyrightFontSize { get; set; }

        public YesNo? RightToLeft { get; set; }

        public string LanguageID { get; set; }

        public long? LanguageCodePage { get; set; }
    }
}