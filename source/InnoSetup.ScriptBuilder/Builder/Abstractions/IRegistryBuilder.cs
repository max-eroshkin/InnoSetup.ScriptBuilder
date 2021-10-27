namespace InnoSetup.ScriptBuilder
{
    using Model.RegistrySection;

    public interface IRegistryBuilder
    {
        RegistryBuilder CreateEntry(RegistryKeys root, string subkey);
    }
}