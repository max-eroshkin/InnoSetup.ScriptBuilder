namespace InnoSetup.ScriptBuilder
{
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
        
        /// <inheritdoc />
        public DeleteBuilder BeforeInstall(string value) => SetPropertyValue(value);

        /// <inheritdoc />
        public DeleteBuilder AfterInstall(string value) => SetPropertyValue(value);

        private DeleteBuilder Name(string value) => SetPropertyValue(value);
        private DeleteBuilder Type(DeleteTypes value) => SetPropertyValue(value);
    }
}