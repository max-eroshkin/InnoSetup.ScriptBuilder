namespace InnoSetup.ScriptBuilder
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Model;
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

        private void WriteAux(TextWriter writer, FileEntry entry)
        {
            foreach (var tuple in entry.Aux)
            {
                if (tuple.Value.value is null)
                    continue;
                
                WriteParameter(writer, tuple.Key, tuple.Value.value, tuple.Value.needQuotes);
            }
        }

        private void WriteProperties(TextWriter writer, FileEntry entry)
        {
            var type = entry.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo info in properties)
            {
                var parameterName = info.Name;
                var value = info.GetValue(entry);
                if (value is null)
                    continue;

                WriteParameter(writer, parameterName, value);
            }
        }

        private void WriteParameter(TextWriter writer, string parameter, object value, bool needQuotes = true)
        {
            switch (value)
            {
                case string str:
                    WriteString(writer, parameter, str, needQuotes);
                    break;
                case Enum enumValue:
                    WriteEnum(writer, parameter, enumValue);
                    break;
                case int number:
                    WriteValue(writer, parameter, number);
                    break;
                case uint number:
                    WriteValue(writer, parameter, number);
                    break;
                case long number:
                    WriteValue(writer, parameter, number);
                    break;
                case ulong number:
                    WriteValue(writer, parameter, number);
                    break;
                case List<GroupPermission> permissions:
                    WritePermissions(writer, parameter, permissions);
                    break;
            }
        }

        private void WritePermissions(TextWriter writer, string parameter, List<GroupPermission> value)
        {
            var val = string.Join(" ", value.Select(x => $"{x.Group.GetString()}-{x.Permission.GetString()}"));
            writer.Write($"{parameter}: {val}; ");
        }

        private void WriteEnum(TextWriter writer, string parameter, Enum value)
        {
            writer.Write($"{parameter}: {value.GetString()}; ");
        }

        private void WriteString(TextWriter writer, string parameter, string value, bool needQuotes = true)
        {
            if (needQuotes)
                writer.Write($"{parameter}: \"{value.Replace("\"", "\"\"")}\"; ");
            else
                writer.Write($"{parameter}: {value}; ");
        }

        private void WriteValue<T>(TextWriter writer, string parameter, T value)
        {
            writer.Write($"{parameter}: {value}; ");
        }
    }
}