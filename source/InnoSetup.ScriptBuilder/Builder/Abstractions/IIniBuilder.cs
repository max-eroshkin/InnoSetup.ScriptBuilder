namespace InnoSetup.ScriptBuilder
{
    public interface IIniBuilder
    {
        IniBuilder CreateEntry(string filename, string section);
    }
}