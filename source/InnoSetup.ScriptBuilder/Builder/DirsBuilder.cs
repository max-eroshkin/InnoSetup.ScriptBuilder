namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;

    public class DirsBuilder :
        CommonParameterSectionBuilderBase<DirsBuilder, DirEntry>,
        IDirsBuilder,
        IComponentsAndTasksBuilder<DirsBuilder>
    {
        public override string SectionName => "Dirs";

        public DirsBuilder CreateEntry(string name)
        {
            CreateEntryInternal();
            Name(name);

            return this;
        }
        
        public DirsBuilder Attribs(AttribsFlags value) => SetPropertyValue(value);
        public DirsBuilder Flags(DirFlags value) => SetPropertyValue(value);
        public DirsBuilder Components(string value) => SetPropertyValue(value);
        public DirsBuilder Tasks(string value) => SetPropertyValue(value);
        
        /// <inheritdoc />
        public DirsBuilder BeforeInstall(string value) => SetPropertyValue(value);

        /// <inheritdoc />
        public DirsBuilder AfterInstall(string value) => SetPropertyValue(value);

        public DirsBuilder AddPermission(Sids group, Permissions permission)
        {
            Data.Permissions ??= new List<GroupPermission>();
            Data.Permissions.Add(new GroupPermission(group, permission));
            return this;
        }
        
        private DirsBuilder Name(string value) => SetPropertyValue(value);
    }
}