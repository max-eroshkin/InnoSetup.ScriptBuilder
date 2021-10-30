namespace InnoSetup.ScriptBuilder
{
    using Model.FileSection;

    public class GenericParameterSectionBuilder : ParameterSectionBuilderBase<GenericParameterSectionBuilder, ParameterSectionEntryBase>, IGenericParameterSectionBuilder
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