namespace InnoSetup.ScriptBuilder
{
    public interface ILanguageEntryBuilder
    {
        LanguagesBuilder CreateEntry(string name, string messagesFile);
    }
}