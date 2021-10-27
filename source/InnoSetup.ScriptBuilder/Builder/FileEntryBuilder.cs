namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;
    using Model.FileSection;

    public class FileEntryBuilder : ParameterSectionBuilder<FileEntryBuilder, FileEntry>, IFileEntryBuilder
    {
        public override string SectionName => "Files";

        public FileEntryBuilder CreateEntry(string source, string destDir)
        {
            CreateEntryInternal();
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
        public FileEntryBuilder Flags(FileFlags value) => SetPropertyValue(value);

        public FileEntryBuilder AddPermission(Sids group, Permissions permission)
        {
            Data.Permissions ??= new List<GroupPermission>();
            Data.Permissions.Add(new GroupPermission(group, permission));
            return this;
        }

        private FileEntryBuilder Source(string value) => SetPropertyValue(value);
        private FileEntryBuilder DestDir(string value) => SetPropertyValue(value);
    }
}