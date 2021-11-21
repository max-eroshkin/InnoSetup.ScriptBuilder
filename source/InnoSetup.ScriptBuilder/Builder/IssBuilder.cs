namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;
    using System.IO;

    public abstract class IssBuilder : IBuilder
    {
        private readonly SetupBuilder _setup = new();
        private readonly FilesBuilder _files = new();
        private readonly ComponentsBuilder _components = new();
        private readonly RegistryBuilder _registry = new();
        private readonly LanguagesBuilder _languages = new();
        private readonly DirsBuilder _dirs = new();

        public ISetupBuilder Setup => _setup;

        public IFileEntryBuilder Files => _files;

        public IComponentEntryBuilder Components => _components;

        public IRegistryBuilder Registry => _registry;

        public ILanguageEntryBuilder Languages => _languages;

        public IDirsBuilder Dirs => _dirs;

        /* Sections to implement
            Types
            Tasks
            Icons
            Ini
            InstallDelete
            CustomMessages
            Messages
            LangOptions
            Run
            UninstallDelete
            UninstallRun
            
            Code
         */

        public GenericSections Sections { get; } = new();

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
            private readonly List<IBuilder> _builders = new();

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