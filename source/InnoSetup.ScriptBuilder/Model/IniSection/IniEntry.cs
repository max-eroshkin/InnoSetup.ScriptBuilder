namespace InnoSetup.ScriptBuilder
{
    public class IniEntry : CommonParameterSectionEntryBase, IHazComponentsAndTasks
    {
        public string Filename { get; set; }

        public string Section { get; set; }

        public string Key { get; set; }

        public string String { get; set; }

        public IniFlags? Flags { get; set; }

        public string Components { get; set; }

        public string Tasks { get; set; }
    }
}