namespace InnoSetup.ScriptBuilder
{
    public class GenericKeyValueSectionBuilder : KeyValueSectionBuilderBase<GenericKeyValueSectionBuilder, KeyValueSection>, IGenericKeyValueSectionBuilder
    {
        public GenericKeyValueSectionBuilder(string name)
        {
            SectionName = name;
        }

        public override string SectionName { get; }

        public GenericKeyValueSectionBuilder CreateEntry()
        {
            return CreateEntryInternal();
        }
    }
}