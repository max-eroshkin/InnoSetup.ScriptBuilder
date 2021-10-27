namespace InnoSetup.ScriptBuilder
{
    public interface ISetupBuilder
    {
        SetupBuilder Create(string appName);
    }
}