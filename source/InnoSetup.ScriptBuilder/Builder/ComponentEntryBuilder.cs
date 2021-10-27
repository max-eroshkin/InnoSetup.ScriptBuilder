namespace InnoSetup.ScriptBuilder
{
    using Model.ComponentSection;

    public class ComponentEntryBuilder : ParameterSectionBuilder<ComponentEntryBuilder, ComponentEntry>, IComponentEntryBuilder
    {
        public override string SectionName => "Components";

        public ComponentEntryBuilder Types(string value) => SetPropertyValue(value);

        public ComponentEntryBuilder ExtraDiskSpaceRequired(long value) => SetPropertyValue(value);

        public ComponentEntryBuilder Flags(ComponentFlags value) => SetPropertyValue(value);

        public ComponentEntryBuilder CreateEntry(string name, string description)
        {
            CreateEntryInternal();
            Name(name);
            Description(description);

            return this;
        }

        private ComponentEntryBuilder Name(string value) => SetPropertyValue(value);
        private ComponentEntryBuilder Description(string value) => SetPropertyValue(value);
    }
}