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
        private readonly TypesBuilder _types = new();
        private readonly RunBuilder _run = new("Run");
        private readonly IconsBuilder _icons = new();
        private readonly RunBuilder _uninstallRun = new("UninstallRun");
        private readonly CodeBuilder _code = new();
        private readonly TasksBuilder _tasks = new();
        private readonly DeleteBuilder _uninstallDelete = new("UninstallDelete");
        private readonly DeleteBuilder _installDelete = new("InstallDelete");
        private readonly GenericKeyValueSectionBuilder _messages = new("Messages");
        private readonly GenericKeyValueSectionBuilder _customMessages = new("CustomMessages");
        private readonly LangOptionsBuilder _langOptionsBuilder = new();
        private readonly IniBuilder _ini = new();

        public ISetupBuilder Setup => _setup;

        public IFileEntryBuilder Files => _files;

        public IComponentEntryBuilder Components => _components;

        public IRegistryBuilder Registry => _registry;

        public ILanguageEntryBuilder Languages => _languages;

        public ILangOptionsBuilder LangOptions => _langOptionsBuilder;

        public IDirsBuilder Dirs => _dirs;

        public ITypesBuilder Types => _types;

        public IRunBuilder Run => _run;

        public IIconBuilder Icons => _icons;

        public IRunBuilder UninstallRun => _uninstallRun;

        public ITasksBuilder Tasks => _tasks;

        public CodeBuilder Code => _code;

        public IDeleteBuilder UninstallDelete => _uninstallDelete;

        public IDeleteBuilder InstallDelete => _installDelete;

        public IGenericKeyValueSectionBuilder Messages => _messages;
        public IIniBuilder INI => _ini;

        public IGenericKeyValueSectionBuilder CustomMessages => _customMessages;

        public GenericSections Sections { get; } = new();

        public DirectivesBuilder Directives { get; } = new();

        public void Write(TextWriter writer)
        {
            Directives.Write(writer);
            _setup.Write(writer);
            _components.Write(writer);
            _tasks.Write(writer);
            _types.Write(writer);
            _languages.Write(writer);
            _langOptionsBuilder.Write(writer);
            _messages.Write(writer);
            _customMessages.Write(writer);
            _dirs.Write(writer);
            _files.Write(writer);
            _icons.Write(writer);
            _registry.Write(writer);
            _run.Write(writer);
            _uninstallRun.Write(writer);
            _uninstallDelete.Write(writer);
            _installDelete.Write(writer);
            _ini.Write(writer);
            Sections.Write(writer);
            _code.Write(writer);
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