namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;

    public class DirEntry : CommonParameterSectionEntryBase, IHazComponentsAndTasks
    {
        public string Name { get; set; }

        public AttribsFlags? Attribs { get; set; }

        public List<GroupPermission> Permissions { get; set; }

        public DirFlags? Flags { get; set; }

        public string Components { get; set; }

        public string Tasks { get; set; }

        public string BeforeInstall { get; set; }

        public string AfterInstall { get; set; }
    }
}