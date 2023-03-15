﻿namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;

    public class FileEntry : CommonParameterSectionEntryBase, IHazComponentsAndTasks
    {
        public string Source { get; set; }

        public string DestDir { get; set; }

        public string DestName { get; set; }

        public AttribsFlags? Attribs { get; set; }

        public string FontInstall { get; set; }

        public string Excludes { get; set; }

        public long? ExternalSize { get; set; }

        public string StrongAssemblyName { get; set; }

        public List<GroupPermission> Permissions { get; set; }

        public FileFlags? Flags { get; set; }

        public string Components { get; set; }

        public string Tasks { get; set; }

        public string BeforeInstall { get; set; }

        public string AfterInstall { get; set; }
    }
}