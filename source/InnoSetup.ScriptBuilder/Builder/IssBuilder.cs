namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;
    using System.IO;

    public abstract class IssBuilder : IBuilder
    {
        private readonly SetupBuilder _setup = new SetupBuilder();
        private readonly FilesBuilder _files = new FilesBuilder();
        private readonly ComponentsBuilder _components = new ComponentsBuilder();
        private readonly RegistryBuilder _registry = new RegistryBuilder();
        private readonly LanguagesBuilder _languages = new LanguagesBuilder();

        public ISetupBuilder Setup => _setup;

        public IFileEntryBuilder Files => _files;

        public IComponentEntryBuilder Components => _components;

        public IRegistryBuilder Registry => _registry;

        public ILanguageEntryBuilder Languages => _languages;

        public GenericSections Sections { get; } = new GenericSections();

        public void Write(TextWriter writer)
        {
            _setup.Write(writer);
            _components.Write(writer);
            _languages.Write(writer);
            _files.Write(writer);
            _registry.Write(writer);
            Sections.Write(writer);
        }

        public override string ToString()
        {
            using var writer = new StringWriter();
            Write(writer);
            return writer.ToString();
        }

        public class GenericSections
        {
            private readonly List<IBuilder> _builders = new List<IBuilder>();

            public IGenericParameterSectionBuilder CreateParameterSection(string name)
            {
                var builder = new GenericParameterSectionBuilder(name);
                _builders.Add(builder);
                return builder;
            }

            public IGenericKeyValueSectionBuilder CreateKeyValueSection(string name)
            {
                var builder = new GenericKeyValueSectionBuilder(name);
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