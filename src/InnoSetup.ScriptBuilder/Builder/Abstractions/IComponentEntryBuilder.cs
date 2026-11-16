namespace InnoSetup.ScriptBuilder
{
    public interface IComponentEntryBuilder
    {
        ComponentsBuilder CreateEntry(string name, string description);
    }
}