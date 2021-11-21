namespace BuilderTests
{
    using InnoSetup.ScriptBuilder;
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
                .CreateEntry("Name", "Description")
                .Types("Types")
                .ExtraDiskSpaceRequired(123456)
                .Flags(ComponentFlags.Fixed | ComponentFlags.Exclusive)
                .Languages("Languages")
                .MinVersion("MinVersion")
                .OnlyBelowVersion("OnlyBelowVersion");
            Components
                .CreateEntry("main", "Main Files").Types("full compact custom").Flags(ComponentFlags.Fixed);

            Dirs.CreateEntry("Name")
                .Attribs(AttribsFlags.System | AttribsFlags.Hidden)
                .Flags(DirFlags.UninsAlwaysUninstall)
                .Components("Components")
                .Tasks("Tasks")
                .Languages("Languages")
                .MinVersion("MinVersion")
                .OnlyBelowVersion("OnlyBelowVersion")
                .AddPermission(Sids.Service, Permissions.Full)
                .AddPermission(Sids.Admins, Permissions.Modify);
            Dirs.CreateEntry("Name");

            Languages.CreateEntry("Name", "MessagesFile")
                .LicenseFile("LicenseFile")
                .InfoAfterFile("InfoAfterFile")
                .InfoBeforeFile("InfoBeforeFile");
            Languages.CreateEntry("Name", "MessageFile");

            Registry.CreateEntry(RegistryKeys.HKCU, "Subkey")
                .ValueName("ValueName")
                .ValueType(ValueTypes.String)
                .ValueData("ValueData")
                .Flags(RegistryFlags.CreateValueIfDoesntExist | RegistryFlags.NoError)
                .Components("Components")
                .Tasks("Tasks")
                .Languages("Languages")
                .MinVersion("MinVersion")
                .OnlyBelowVersion("OnlyBelowVersion")
                .AddPermission(Sids.Service, Permissions.Full)
                .AddPermission(Sids.Admins, Permissions.Modify);
            Registry.CreateEntry(RegistryKeys.HKU, @"Software\My Company\My Program");

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