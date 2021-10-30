namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;
    using Model.FileSection;
    
    public class FilesBuilder : ParameterSectionBuilderBase<FilesBuilder, FileEntry>, IFileEntryBuilder
    {
        public override string SectionName => "Files";

        public FilesBuilder CreateEntry(string source, string destDir)
        {
            CreateEntryInternal();
            Source(source);
            DestDir(destDir);

            return this;
        }

        public FilesBuilder DestName(string value) => SetPropertyValue(value);
        public FilesBuilder Attribs(AttribsFlags value) => SetPropertyValue(value);
        public FilesBuilder FontInstall(string value) => SetPropertyValue(value);
        public FilesBuilder Excludes(string value) => SetPropertyValue(value);
        public FilesBuilder ExternalSize(string value) => SetPropertyValue(value);
        public FilesBuilder StrongAssemblyName(string value) => SetPropertyValue(value);
        public FilesBuilder Flags(FileFlags value) => SetPropertyValue(value);
        public FilesBuilder Components(FileFlags value) => SetPropertyValue(value);
        public FilesBuilder Tasks(FileFlags value) => SetPropertyValue(value);

        public FilesBuilder AddPermission(Sids group, Permissions permission)
        {
            Data.Permissions ??= new List<GroupPermission>();
            Data.Permissions.Add(new GroupPermission(group, permission));
            return this;
        }

        private FilesBuilder Source(string value) => SetPropertyValue(value);
        private FilesBuilder DestDir(string value) => SetPropertyValue(value);
    }
}