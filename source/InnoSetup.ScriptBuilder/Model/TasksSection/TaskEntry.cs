namespace InnoSetup.ScriptBuilder
{
    public class TaskEntry : CommonParameterSectionEntryBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string GroupDescription { get; set; }

        public string Components { get; set; }

        public TaskFlags? Flags { get; set; }
    }
}