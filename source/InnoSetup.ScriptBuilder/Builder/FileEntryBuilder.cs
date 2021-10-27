namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using Model.FileSection;

    public class FileEntryBuilder : SectionBuilderBase<FileEntryBuilder, FileEntry>, IFileEntryBuilder, IBuilder
    {
        private List<FileEntry> _entryList;

        public FileEntryBuilder CreateEntry(string source, string destDir)
        {
            _entryList ??= new List<FileEntry>();
            _entryList.Add(Data = new FileEntry());
            Source(source);
            DestDir(destDir);

            return this;
        }

        public FileEntryBuilder DestName(string value) => SetPropertyValue(value);
        public FileEntryBuilder Attribs(AttribsFlags value) => SetPropertyValue(value);
        public FileEntryBuilder FontInstall(string value) => SetPropertyValue(value);
        public FileEntryBuilder Excludes(string value) => SetPropertyValue(value);
        public FileEntryBuilder ExternalSize(string value) => SetPropertyValue(value);
        public FileEntryBuilder StrongAssemblyName(string value) => SetPropertyValue(value);

        public FileEntryBuilder AddPermission(Sids group, Permissions permission)
        {
            Data.Permissions ??= new List<GroupPermission>();
            Data.Permissions.Add(new GroupPermission(group, permission));
            return this;
        }

        public FileEntryBuilder Flags(FileFlags value) => SetPropertyValue(value);

        public void Write(TextWriter writer)
        {
            if (_entryList?.Count > 0)
            {
                writer.WriteLine("[Files]");
                foreach (var entry in _entryList)
                    WriteEntry(writer, entry);
            }
        }

        private FileEntryBuilder Source(string value) => SetPropertyValue(value);
        private FileEntryBuilder DestDir(string value) => SetPropertyValue(value);

        private void WriteEntry(TextWriter writer, FileEntry entry)
        {
            WriteProperties(writer, entry);
            WriteAux(writer, entry);
            writer.WriteLine();
        }

        private void WriteProperties(TextWriter writer, FileEntry entry)
        {
            var type = entry.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo info in properties)
            {
                var value = info.GetValue(entry);
                if (value is null)
                    continue;

                var str = value.GetString();
                if (str is not null)
                    writer.Write($"{info.Name}: {str}; ");
            }
        }

        private void WriteAux(TextWriter writer, FileEntry entry)
        {
            foreach (var parameter in entry.Aux)
            {
                if (parameter.Value.value is null)
                    continue;
                
                var str = parameter.Value.value.GetString(parameter.Value.needQuotes);
                if (str is not null)
                    writer.Write($"{parameter.Key}: {str}; ");
            }
        }
    }
}