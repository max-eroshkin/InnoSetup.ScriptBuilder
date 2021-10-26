using System.IO;

namespace InnoSetup.ScriptBuilder.Builder
{
    public abstract class ScriptBuilderBase : IBuilder
    {
        private SetupBuilder _setup;
        private FileEntryBuilder _files;
        public ISetupBuilder Setup => _setup ??= new SetupBuilder();
        public IFileEntryBuilder Files => _files ??= new FileEntryBuilder();
        public void Write(TextWriter writer)
        {
            _setup.Write(writer);
            writer.WriteLine();
            _files.Write(writer);
        }
    }
}