namespace InnoSetup.ScriptBuilder
{
    using Model.ComponentSection;

    public class ComponentsBuilder : CommonParameterSectionBuilderBase<ComponentsBuilder, ComponentEntry>, IComponentEntryBuilder
    {
        public override string SectionName => "Components";

        public ComponentsBuilder Types(string value) => SetPropertyValue(value);

        public ComponentsBuilder ExtraDiskSpaceRequired(long value) => SetPropertyValue(value);

        public ComponentsBuilder Flags(ComponentFlags value) => SetPropertyValue(value);

        public ComponentsBuilder CreateEntry(string name, string description)
        {
            CreateEntryInternal();
            Name(name);
            Description(description);

            return this;
        }

        private ComponentsBuilder Name(string value) => SetPropertyValue(value);
        private ComponentsBuilder Description(string value) => SetPropertyValue(value);
    }
}