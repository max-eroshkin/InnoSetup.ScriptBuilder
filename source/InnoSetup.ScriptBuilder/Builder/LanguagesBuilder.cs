namespace InnoSetup.ScriptBuilder
{
    using Model.LanguageSection;

    public class LanguagesBuilder : ParameterSectionBuilderBase<LanguagesBuilder, LanguageEntry>, ILanguageEntryBuilder
    {
        public override string SectionName => "Languages";

        public LanguagesBuilder CreateEntry(string name, string messageFile)
        {
            CreateEntryInternal();
            Name(name);
            MessageFile(messageFile);
            return this;
        }

        private LanguagesBuilder Name(string value) => SetPropertyValue(value);
        private LanguagesBuilder MessageFile(string value) => SetPropertyValue(value);
        private LanguagesBuilder LicenseFile(string value) => SetPropertyValue(value);
        private LanguagesBuilder InfoAfterFile(string value) => SetPropertyValue(value);
        private LanguagesBuilder InfoBeforeFile(string value) => SetPropertyValue(value);
    }
}