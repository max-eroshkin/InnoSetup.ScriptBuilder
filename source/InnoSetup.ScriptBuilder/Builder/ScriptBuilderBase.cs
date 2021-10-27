namespace InnoSetup.ScriptBuilder
{
    using System.IO;

    public abstract class ScriptBuilderBase : IBuilder
    {
        private SetupBuilder _setup;
        private FileEntryBuilder _files;
        private ComponentEntryBuilder _components;

        public ISetupBuilder Setup => _setup ??= new SetupBuilder();

        public IFileEntryBuilder Files => _files ??= new FileEntryBuilder();
        public IComponentEntryBuilder Components => _components ??= new ComponentEntryBuilder();

        public void Write(TextWriter writer)
        {
            _setup.Write(writer);
            _files.Write(writer);
            _components.Write(writer);
        }
    }
}