namespace InnoSetup.ScriptBuilder
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Model.FileSection;

    public class FileEntryBuilder : BuilderBase<FileEntryBuilder, FileEntry>, IFileEntryBuilder, IBuilder
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

        public FileEntryBuilder Flags(FileSectionFlags value) => SetPropertyValue(value);

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
            writer.WriteLine();
        }

        private void WriteProperties(TextWriter writer, FileEntry entry)
        {
            var type = entry.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // text props
            foreach (PropertyInfo info in properties)
            {
                var value = info.GetValue(entry);
                if (value is null)
                    continue;

                switch (value)
                {
                    case string str:
                        WriteString(writer, info, str);
                        break;
                    case Enum enumValue:
                        WriteEnum(writer, info, enumValue);
                        break;
                    case int number:
                        WriteValue(writer, info, number);
                        break;
                    case uint number:
                        WriteValue(writer, info, number);
                        break;
                    case long number:
                        WriteValue(writer, info, number);
                        break;
                    case ulong number:
                        WriteValue(writer, info, number);
                        break;
                    case List<GroupPermission> permissions:
                        WritePermissions(writer, info, permissions);
                        break;
                    default: continue;
                }
            }
        }

        private void WritePermissions(TextWriter writer, PropertyInfo info, List<GroupPermission> value)
        {
            var val = string.Join(" ", value.Select(x => $"{x.Group.GetString()}-{x.Permission.GetString()}"));
            writer.Write($"{info.Name}: {val}; ");
        }

        private void WriteEnum(TextWriter writer, PropertyInfo info, Enum value)
        {
            writer.Write($"{info.Name}: {value.GetString()}; ");
        }

        private void WriteString(TextWriter writer, PropertyInfo info, string value)
        {
            writer.Write($"{info.Name}: \"{value.Replace("\"", "\"\"")}\"; ");
        }

        private void WriteValue<T>(TextWriter writer, PropertyInfo info, T value)
        {
            writer.Write($"{info.Name}: {value}; ");
        }
    }
}