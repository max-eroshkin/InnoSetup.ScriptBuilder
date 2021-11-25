namespace InnoSetup.ScriptBuilder
{
    using Model.TypesSection;

    public class TypesBuilder : CommonParameterSectionBuilderBase<TypesBuilder, TypeEntry>, ITypesBuilder
    {
        public override string SectionName => "Types";

        public TypesBuilder Flags(TypeFlags value) => SetPropertyValue(value);

        public TypesBuilder CreateEntry(string name, string description)
        {
            CreateEntryInternal();
            Name(name);
            Description(description);

            return this;
        }

        private TypesBuilder Name(string value) => SetPropertyValue(value);
        private TypesBuilder Description(string value) => SetPropertyValue(value);
    }
}