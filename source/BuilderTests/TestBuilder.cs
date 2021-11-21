using InnoSetup.ScriptBuilder;

namespace BuilderTests
{
    using InnoSetup.ScriptBuilder.Model.SetupSection;

    public class TestBuilder : IssBuilder
    {
        public TestBuilder()
        {
            Setup.Create("BimTools.Support")
                .AppVersion("1.2.5.1634640046")
                .DefaultDirName(@"{userappdata}\Autodesk\Revit\Addins\2019\SupportTools")
                .PrivilegesRequired(PrivilegesRequired.Lowest)
                .OutputBaseFilename("BimTools.Support_2021_1.2.5.1634640046")
                .SetupIconFile("trayIcon.ico")
                .UninstallDisplayIcon("trayIcon.ico")
                .DisableDirPage(YesNo.Yes)
                .Parameter("AuxParam", "1.2.546", false);
            
            Files.CreateEntry("Source", "DestDir")
                .DestName("DestName")
                .Attribs(AttribsFlags.System | AttribsFlags.Readonly)
                .FontInstall("FontInstall")
                .Excludes("Excludes")
                .ExternalSize(123456)
                .StrongAssemblyName("StrongAssemblyName")
                .Flags(FileFlags.Sign | FileFlags.Sign)
                .Components("Components")
                .Tasks("Tasks")
                .Languages("Languages")
                .MinVersion("MinVersion")
                .OnlyBelowVersion("OnlyBelowVersion")
                .AddPermission(Sids.Service, Permissions.Full)
                .AddPermission(Sids.Admins, Permissions.Modify);
            Files.CreateEntry(source: "SupportTools.addin", destDir: @"{userappdata}\Autodesk\Revit\Addins\2019");

            Components
                .CreateEntry("main", "Main Files").Types("full compact custom").Flags(ComponentFlags.Fixed);

            Registry.CreateEntry(RegistryKeys.HKU, @"Software\My Company\My Program")
                .ValueName("Name").ValueType(ValueTypes.String).ValueData("Test app");

            Sections.CreateParameterSection("Registry")
                .CreateEntry()
                    .Parameter("Root", RegistryKeys.HKU)
                    .Parameter("Subkey", @"Software\My Company\My Program")
                    .Parameter("ValueName", "Name")
                    .Parameter("ValueType", ValueTypes.String)
                    .Parameter("ValueData", "Test app");

            Sections.CreateKeyValueSection("Messages")
                .CreateEntry()
                .Parameter("BeveledLabel", @"Inno Setup")
                .Parameter("HelpTextNote", @"/PORTABLE=1%nEnable portable mode.");
        }
    }
}