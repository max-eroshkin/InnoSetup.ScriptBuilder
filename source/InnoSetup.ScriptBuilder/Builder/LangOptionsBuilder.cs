namespace InnoSetup.ScriptBuilder
{
    using Model.LangOptionsSection;

    public class LangOptionsBuilder :
        KeyValueSectionBuilderBase<LangOptionsBuilder, LangOptionsSection>,
        ILangOptionsBuilder
    {
        public override string SectionName => "LangOptions";

        public LangOptionsBuilder Create()
        {
            CreateEntryInternal();
            return this;
        }

        public LangOptionsBuilder LanguageName(string value) => SetPropertyValue(value);

        public LangOptionsBuilder DialogFontName(string value) => SetPropertyValue(value);

        public LangOptionsBuilder DialogFontSize(int value) => SetPropertyValue(value);

        public LangOptionsBuilder WelcomeFontName(string value) => SetPropertyValue(value);

        public LangOptionsBuilder WelcomeFontSize(int value) => SetPropertyValue(value);

        public LangOptionsBuilder TitleFontName(string value) => SetPropertyValue(value);

        public LangOptionsBuilder TitleFontSize(int value) => SetPropertyValue(value);

        public LangOptionsBuilder CopyrightFontName(string value) => SetPropertyValue(value);

        public LangOptionsBuilder CopyrightFontSize(int value) => SetPropertyValue(value);

        public LangOptionsBuilder RightToLeft(YesNo value) => SetPropertyValue(value);

        public LangOptionsBuilder LanguageID(string value) => SetPropertyValue(value);

        public LangOptionsBuilder LanguageCodePage(long value) => SetPropertyValue(value);
    }
}