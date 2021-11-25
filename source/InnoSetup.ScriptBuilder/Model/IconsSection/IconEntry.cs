namespace InnoSetup.ScriptBuilder.Model.IconsSection
{
    public class IconEntry : CommonParameterSectionEntryBase, IHazComponentsAndTasks
    {
        public string Name { get; set; }

        public string Filename { get; set; }

        public string Parameters { get; set; }

        public string WorkingDir { get; set; }

        public string HotKey { get; set; }

        public string Comment { get; set; }

        public string IconFilename { get; set; }

        public int? IconIndex { get; set; }

        public string AppUserModelID { get; set; }

        public string AppUserModelToastActivatorCLSID { get; set; }

        public IconFlags? Flags { get; set; }

        public string Components { get; set; }

        public string Tasks { get; set; }
    }

    /* = 1
     * = 1 << 1
     * = 1 << 2
     * = 1 << 3
     * = 1 << 4
     * = 1 << 5
     * = 1 << 6
     * = 1 << 7
     * = 1 << 8
     * = 1 << 9
     * = 1 << 10
     * = 1 << 11
     * = 1 << 12
     * = 1 << 13
     * = 1 << 14
     */
}