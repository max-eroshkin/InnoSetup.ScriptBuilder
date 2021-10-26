namespace InnoSetup.ScriptBuilder
{
    public interface IFileEntryBuilder
    {
        FileEntryBuilder CreateEntry(string source, string destDir);
    }
}