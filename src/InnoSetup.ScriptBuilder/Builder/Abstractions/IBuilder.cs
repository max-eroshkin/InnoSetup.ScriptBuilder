namespace InnoSetup.ScriptBuilder
{
    using System.IO;

    public interface IBuilder
    {
        void Write(TextWriter writer);
    }
}