namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;
    using System.IO;

    public abstract class ScriptBuilderBase : IBuilder
    {
        private SetupBuilder _setup;
        private FileEntryBuilder _files;
        private ComponentEntryBuilder _components;

        public ISetupBuilder Setup => _setup ??= new SetupBuilder();

        public IFileEntryBuilder Files => _files ??= new FileEntryBuilder();

        public IComponentEntryBuilder Components => _components ??= new ComponentEntryBuilder();

        public OtherSection Sections { get; } = new OtherSection();

        public void Write(TextWriter writer)
        {
            _setup.Write(writer);
            _files.Write(writer);
            _components.Write(writer);
            Sections.Write(writer);
        }

        public class OtherSection
        {
            private readonly List<IBuilder> _builders = new List<IBuilder>();
            public ICreateParameterSectionBuilder CreateParameterSection(string name)
            {
                var builder = new CreateParameterSectionBuilder(name);
                _builders.Add(builder);
                return builder;
            }

            public void Write(TextWriter writer)
            {
                foreach (var builder in _builders)
                {
                    builder.Write(writer);
                }
            }
        }
    }
}