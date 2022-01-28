namespace InnoSetup.ScriptBuilder
{
    /// <summary>
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=commonparams">ISS documentation</a>.
    /// </summary>
    public class CommonParameterSectionEntryBase : ModelBase
    {
        public string Languages { get; set; }
        public string MinVersion { get; set; }
        public string OnlyBelowVersion { get; set; }
        public string Check { get; set; }
    }
}