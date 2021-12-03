namespace BuilderTests
{
    using System.Collections.Generic;
    using InnoSetup.ScriptBuilder;

    public class TasksTests: ParameterSectionTestsBase<TaskEntry>
    {
        protected override string SectionName => "Tasks";

        protected override Dictionary<string, string> ReferenceData => new()
        {
            { "Name", "\"Name\"" },
            { "Description", "\"Description\"" },
            { "GroupDescription", "\"GroupDescription\"" },
            { "Components", "\"Components\"" },
            { "Flags", "restart checkedonce" },
            { "Languages", "\"Languages\"" },
            { "MinVersion", "\"MinVersion\"" },
            { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
        };
    }
}