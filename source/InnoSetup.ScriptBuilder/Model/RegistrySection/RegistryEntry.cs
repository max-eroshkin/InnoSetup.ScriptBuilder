namespace InnoSetup.ScriptBuilder.Model.RegistrySection
{
    using System.Collections.Generic;
    using FileSection;

    public class RegistryEntry : CommonParameterSectionEntryBase, IHazComponentsAndTasks
    {
        public RegistryKeys? Root { get; set; }

        public string Subkey { get; set; }

        public ValueTypes? ValueType { get; set; }

        public string ValueName { get; set; }

        public string ValueData { get; set; }

        public List<GroupPermission> Permissions { get; set; }
        public RegistryFlags? Flags { get; set; }
        public string Components { get; set; }
        public string Tasks { get; set; }
    }
}