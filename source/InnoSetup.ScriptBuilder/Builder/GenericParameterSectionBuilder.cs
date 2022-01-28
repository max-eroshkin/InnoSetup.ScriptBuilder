namespace InnoSetup.ScriptBuilder
{
    public class GenericParameterSectionBuilder :
        ParameterSectionBuilderBase<GenericParameterSectionBuilder, CommonParameterSectionEntryBase>,
        IGenericParameterSectionBuilder
    {
        public GenericParameterSectionBuilder(string name)
        {
            SectionName = name;
        }

        public override string SectionName { get; }

        public GenericParameterSectionBuilder CreateEntry()
        {
            return CreateEntryInternal();
        }
    }
}