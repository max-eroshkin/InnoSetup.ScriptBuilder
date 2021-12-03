namespace InnoSetup.ScriptBuilder
{
    public class ComponentEntry : CommonParameterSectionEntryBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Types { get; set; }

        public long? ExtraDiskSpaceRequired { get; set; }

        public ComponentFlags? Flags { get; set; }
    }
}