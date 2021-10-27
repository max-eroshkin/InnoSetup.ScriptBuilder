namespace InnoSetup.ScriptBuilder
{
    using Model.FileSection;

    public class CreateParameterSectionBuilder : ParameterSectionBuilder<CreateParameterSectionBuilder, ParameterSectionEntryBase>, ICreateParameterSectionBuilder
    {
        public CreateParameterSectionBuilder(string name)
        {
            SectionName = name;
        }

        public override string SectionName { get; }

        public CreateParameterSectionBuilder CreateEntry()
        {
            return CreateEntryInternal();
        }
    }
}