namespace InnoSetup.ScriptBuilder
{
    using Model.DeleteSection;

    public class DeleteBuilder :
        CommonParameterSectionBuilderBase<DeleteBuilder, DeleteEntry>,
        IDeleteBuilder,
        IComponentsAndTasksBuilder<DeleteBuilder>
    {
        public DeleteBuilder(string sectionName)
        {
            SectionName = sectionName;
        }

        public override string SectionName { get; }

        public DeleteBuilder CreateEntry(DeleteTypes type, string name)
        {
            CreateEntryInternal();
            Type(type);
            Name(name);

            return this;
        }

        public DeleteBuilder Components(string value) => SetPropertyValue(value);

        public DeleteBuilder Tasks(string value) => SetPropertyValue(value);
        private DeleteBuilder Name(string value) => SetPropertyValue(value);
        private DeleteBuilder Type(DeleteTypes value) => SetPropertyValue(value);
    }
}