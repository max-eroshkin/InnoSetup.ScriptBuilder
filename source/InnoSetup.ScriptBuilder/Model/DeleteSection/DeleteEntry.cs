namespace InnoSetup.ScriptBuilder.Model.DeleteSection
{
    public class DeleteEntry : CommonParameterSectionEntryBase, IHazComponentsAndTasks
    {
        public string Name { get; set; }

        public DeleteTypes? Type { get; set; }

        public string Components { get; set; }

        public string Tasks { get; set; }
    }
}