namespace InnoSetup.ScriptBuilder
{
    public interface IFileEntryBuilder
    {
        FilesBuilder CreateEntry(string source, string destDir);
    }
}