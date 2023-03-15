namespace InnoSetup.ScriptBuilder
{
    public class DeleteEntry : CommonParameterSectionEntryBase, IHazComponentsAndTasks
    {
        public string Name { get; set; }

        public DeleteTypes? Type { get; set; }

        public string Components { get; set; }

        public string Tasks { get; set; }

        public string BeforeInstall { get; set; }

        public string AfterInstall { get; set; }
    }
}