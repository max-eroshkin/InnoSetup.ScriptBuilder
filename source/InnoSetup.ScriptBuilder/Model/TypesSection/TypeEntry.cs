namespace InnoSetup.ScriptBuilder.Model.TypesSection
{
    public class TypeEntry : CommonParameterSectionEntryBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeFlags? Flags { get; set; }
    }
}