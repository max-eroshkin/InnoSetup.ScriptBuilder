namespace InnoSetup.ScriptBuilder
{
    public interface IIconBuilder
    {
        IconsBuilder CreateEntry(string name, string filename);
    }
}