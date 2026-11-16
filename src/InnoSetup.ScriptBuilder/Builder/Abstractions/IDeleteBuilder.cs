namespace InnoSetup.ScriptBuilder
{
    public interface IDeleteBuilder
    {
        DeleteBuilder CreateEntry(DeleteTypes type, string name);
    }
}