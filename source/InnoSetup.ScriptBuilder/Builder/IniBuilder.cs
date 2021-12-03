namespace InnoSetup.ScriptBuilder
{
    public class IniBuilder :
        CommonParameterSectionBuilderBase<IniBuilder, IniEntry>,
        IIniBuilder,
        IComponentsAndTasksBuilder<IniBuilder>
    {
        public override string SectionName => "INI";

        public IniBuilder CreateEntry(string filename, string section)
        {
            CreateEntryInternal();
            Filename(filename);
            Section(section);

            return this;
        }

        public IniBuilder Key(string value) => SetPropertyValue(value);

        public IniBuilder String(string value) => SetPropertyValue(value);

        public IniBuilder Flags(IniFlags value) => SetPropertyValue(value);

        public IniBuilder Components(string value) => SetPropertyValue(value);

        public IniBuilder Tasks(string value) => SetPropertyValue(value);

        private IniBuilder Filename(string value) => SetPropertyValue(value);

        private IniBuilder Section(string value) => SetPropertyValue(value);
    }
}