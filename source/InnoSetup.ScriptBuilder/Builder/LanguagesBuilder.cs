namespace InnoSetup.ScriptBuilder
{
    using Model.LanguageSection;

    public class LanguagesBuilder : ParameterSectionBuilderBase<LanguagesBuilder, LanguageEntry>, ILanguageEntryBuilder
    {
        public override string SectionName => "Languages";

        public LanguagesBuilder CreateEntry(string name, string messagesFile)
        {
            CreateEntryInternal();
            Name(name);
            MessagesFile(messagesFile);
            return this;
        }

        public LanguagesBuilder LicenseFile(string value) => SetPropertyValue(value);
        public LanguagesBuilder InfoAfterFile(string value) => SetPropertyValue(value);
        public LanguagesBuilder InfoBeforeFile(string value) => SetPropertyValue(value);
        private LanguagesBuilder Name(string value) => SetPropertyValue(value);
        private LanguagesBuilder MessagesFile(string value) => SetPropertyValue(value);
    }
}