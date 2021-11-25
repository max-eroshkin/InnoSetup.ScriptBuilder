namespace InnoSetup.ScriptBuilder
{
    using Model.RunSection;

    public class RunBuilder :
        CommonParameterSectionBuilderBase<RunBuilder, RunEntry>,
        IRunBuilder,
        IComponentsAndTasksBuilder<RunBuilder>
    {
        public override string SectionName => "Run";
        
        public RunBuilder CreateEntry(string fileName)
        {
            CreateEntryInternal();
            FileName(fileName);

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
        
        private RunBuilder FileName(string value) => SetPropertyValue(value);
    }
}