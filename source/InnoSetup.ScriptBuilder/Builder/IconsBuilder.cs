namespace InnoSetup.ScriptBuilder
{
    using Model.IconsSection;

    public class IconsBuilder :
        CommonParameterSectionBuilderBase<IconsBuilder, IconEntry>,
        IIconBuilder,
        IComponentsAndTasksBuilder<IconsBuilder>
    {
        public override string SectionName => "Icons";

        public IconsBuilder CreateEntry(string name, string filename)
        {
            CreateEntryInternal();
            Name(name);
            Filename(filename);

            return this;
        }

        public IconsBuilder Parameters(string value) => SetPropertyValue(value);

        public IconsBuilder WorkingDir(string value) => SetPropertyValue(value);

        public IconsBuilder HotKey(string value) => SetPropertyValue(value);

        public IconsBuilder Comment(string value) => SetPropertyValue(value);

        public IconsBuilder IconFilename(string value) => SetPropertyValue(value);

        public IconsBuilder IconIndex(int value) => SetPropertyValue(value);

        public IconsBuilder AppUserModelID(string value) => SetPropertyValue(value);

        public IconsBuilder AppUserModelToastActivatorCLSID(string value) => SetPropertyValue(value);

        public IconsBuilder Flags(IconFlags value) => SetPropertyValue(value);

        public IconsBuilder Components(string value) => SetPropertyValue(value);

        public IconsBuilder Tasks(string value) => SetPropertyValue(value);

        private IconsBuilder Name(string value) => SetPropertyValue(value);

        private IconsBuilder Filename(string value) => SetPropertyValue(value);
    }
}