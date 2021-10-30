namespace InnoSetup.ScriptBuilder
{
    public interface IRegistryBuilder
    {
        RegistryBuilder CreateEntry(RegistryKeys root, string subkey);
    }
}