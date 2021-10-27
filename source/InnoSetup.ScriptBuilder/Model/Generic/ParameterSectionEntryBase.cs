namespace InnoSetup.ScriptBuilder.Model.FileSection
{
    public class ParameterSectionEntryBase : ModelBase
    {
        public string Languages { get; set; }
        public string MinVersion { get; set; }
        public string OnlyBelowVersion { get; set; }
    }
}