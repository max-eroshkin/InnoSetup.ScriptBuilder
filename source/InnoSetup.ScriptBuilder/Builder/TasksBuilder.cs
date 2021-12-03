namespace InnoSetup.ScriptBuilder
{
    public class TasksBuilder :
        CommonParameterSectionBuilderBase<TasksBuilder, TaskEntry>,
        ITasksBuilder
    {
        public override string SectionName => "Tasks";

        public TasksBuilder CreateEntry(string name, string description)
        {
            CreateEntryInternal();
            Name(name);
            Description(description);
            return this;
        }

        public TasksBuilder GroupDescription(string value) => SetPropertyValue(value);

        public TasksBuilder Components(string value) => SetPropertyValue(value);

        public TasksBuilder Flags(TaskFlags value) => SetPropertyValue(value);
        private TasksBuilder Name(string value) => SetPropertyValue(value);

        private TasksBuilder Description(string value) => SetPropertyValue(value);
    }
}