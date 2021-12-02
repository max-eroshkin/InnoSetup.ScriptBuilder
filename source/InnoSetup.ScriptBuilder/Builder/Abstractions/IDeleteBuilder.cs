namespace InnoSetup.ScriptBuilder
{
    using Model.DeleteSection;

    public interface IDeleteBuilder
    {
        DeleteBuilder CreateEntry(DeleteTypes type, string name);
    }
}