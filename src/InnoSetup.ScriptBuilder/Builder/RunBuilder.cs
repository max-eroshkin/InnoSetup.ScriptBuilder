namespace InnoSetup.ScriptBuilder
{
    public class RunBuilder :
        CommonParameterSectionBuilderBase<RunBuilder, RunEntry>,
        IRunBuilder,
        IComponentsAndTasksBuilder<RunBuilder>
    {
        public RunBuilder(string sectionName)
        {
            SectionName = sectionName;
        }

        public override string SectionName { get; }

        public RunBuilder CreateEntry(string fileName)
        {
            CreateEntryInternal();
            Filename(fileName);

            return this;
        }

        public RunBuilder Description(string value) => SetPropertyValue(value);

        public RunBuilder Parameters(string value) => SetPropertyValue(value);

        public RunBuilder WorkingDir(string value) => SetPropertyValue(value);

        public RunBuilder StatusMsg(string value) => SetPropertyValue(value);

        public RunBuilder RunOnceId(string value) => SetPropertyValue(value);

        public RunBuilder Verb(string value) => SetPropertyValue(value);

        public RunBuilder Flags(RunFlags value) => SetPropertyValue(value);

        public RunBuilder Components(string value) => SetPropertyValue(value);

        public RunBuilder Tasks(string value) => SetPropertyValue(value);

        /// <inheritdoc />
        public RunBuilder BeforeInstall(string value) => SetPropertyValue(value);

        /// <inheritdoc />
        public RunBuilder AfterInstall(string value) => SetPropertyValue(value);

        private RunBuilder Filename(string value) => SetPropertyValue(value);
    }
}