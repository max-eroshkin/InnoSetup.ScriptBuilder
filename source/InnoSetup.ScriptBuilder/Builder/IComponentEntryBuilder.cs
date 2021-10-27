namespace InnoSetup.ScriptBuilder
{
    public interface IComponentEntryBuilder
    {
        ComponentEntryBuilder CreateEntry(string name, string description);
    }
}