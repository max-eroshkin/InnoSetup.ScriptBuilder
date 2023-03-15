namespace InnoSetup.ScriptBuilder
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

        public string BeforeInstall { get; set; }

        public string AfterInstall { get; set; }
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
     * = 1 << 15
     * = 1 << 16
     * = 1 << 17
     * = 1 << 18
     * = 1 << 19
     * = 1 << 20
     * = 1 << 21
     * = 1 << 22
     * = 1 << 23
     * = 1 << 24
     * = 1 << 25
     * = 1 << 26
     * = 1 << 27
     * = 1 << 28
     * = 1 << 29
     * = 1 << 30
     * = 1 << 31
     * = 1 << 32
     * = 1 << 33
     * = 1 << 34
     * = 1 << 35
     * = 1 << 36
     * = 1 << 37
     * = 1 << 38
     * = 1 << 39
     */
}