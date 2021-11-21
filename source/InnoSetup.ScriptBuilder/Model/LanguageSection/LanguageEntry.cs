namespace InnoSetup.ScriptBuilder.Model.LanguageSection
{
    using FileSection;
    public class LanguageEntry : ModelBase
    {
        public string Name { get; set; }

        public string MessagesFile { get; set; }

        public string LicenseFile { get; set; }

        public string InfoAfterFile { get; set; }

        public string InfoBeforeFile { get; set; }
    }
}
