namespace InnoSetup.ScriptBuilder
{
    public interface ITypesBuilder
    {
        TypesBuilder CreateEntry(string name, string description);
    }
}