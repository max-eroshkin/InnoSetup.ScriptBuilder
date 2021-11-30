namespace InnoSetup.ScriptBuilder
{
    public interface ITasksBuilder
    {
        TasksBuilder CreateEntry(string name, string description);
    }
}