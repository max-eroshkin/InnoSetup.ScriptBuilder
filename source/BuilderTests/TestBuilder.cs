namespace BuilderTests
{
    using InnoSetup.ScriptBuilder;

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
                .AddPermission(Sids.Admins, Permissions.Modify)
                .Check("Check");
            Files.CreateEntry(source: "SupportTools.addin", destDir: @"{userappdata}\Autodesk\Revit\Addins\2019");

            Components
                .CreateEntry("Name", "Description")
                .Types("Types")
                .ExtraDiskSpaceRequired(123456)
                .Flags(ComponentFlags.Fixed | ComponentFlags.Exclusive)
                .Languages("Languages")
                .MinVersion("MinVersion")
                .OnlyBelowVersion("OnlyBelowVersion")
                .Check("Check");
            Components.CreateEntry("main", "Main Files");

            Tasks.CreateEntry("Name", "Description")
                .Components("Components")
                .GroupDescription("GroupDescription")
                .Flags(TaskFlags.CheckedOnce | TaskFlags.Restart)
                .Languages("Languages")
                .MinVersion("MinVersion")
                .OnlyBelowVersion("OnlyBelowVersion")
                .Check("Check");
            Tasks.CreateEntry("Name", "Description");

            Types
                .CreateEntry("Name", "Description")
                .Flags(TypeFlags.IsCustom)
                .Languages("Languages")
                .MinVersion("MinVersion")
                .OnlyBelowVersion("OnlyBelowVersion")
                .Check("Check");
            Types.CreateEntry("Name", "Description");

            Dirs.CreateEntry("Name")
                .Attribs(AttribsFlags.System | AttribsFlags.Hidden)
                .Flags(DirFlags.UninsAlwaysUninstall)
                .Components("Components")
                .Tasks("Tasks")
                .Languages("Languages")
                .MinVersion("MinVersion")
                .OnlyBelowVersion("OnlyBelowVersion")
                .AddPermission(Sids.Service, Permissions.Full)
                .AddPermission(Sids.Admins, Permissions.Modify)
                .Check("Check");
            Dirs.CreateEntry("Name");
            
            Icons.CreateEntry("Name", "Filename")
                .Parameters("Parameters")
                .WorkingDir("WorkingDir")
                .Comment("Comment")
                .HotKey("HotKey")
                .IconFilename("IconFilename")
                .IconIndex(11)
                .AppUserModelID("AppUserModelID")
                .AppUserModelToastActivatorCLSID("AppUserModelToastActivatorCLSID")
                .Flags(IconFlags.UninsNeverUninstall | IconFlags.CloseOnExit)
                .Components("Components")
                .Tasks("Tasks")
                .Languages("Languages")
                .MinVersion("MinVersion")
                .OnlyBelowVersion("OnlyBelowVersion")
                .Check("Check");
            Icons.CreateEntry("Name", "Filename");

            Languages.CreateEntry("Name", "MessagesFile")
                .LicenseFile("LicenseFile")
                .InfoAfterFile("InfoAfterFile")
                .InfoBeforeFile("InfoBeforeFile")
                .Check("Check");
            Languages.CreateEntry("Name", "MessageFile");

            LangOptions.Create().LanguageName("LanguageName");

            INI.CreateEntry("Filename", "Section")
                .String("String")
                .Key("Key")
                .Flags(IniFlags.UninsDeleteEntry | IniFlags.CreateKeyIfDoesntExist)
                .Components("Components")
                .Tasks("Tasks")
                .Languages("Languages")
                .MinVersion("MinVersion")
                .OnlyBelowVersion("OnlyBelowVersion")
                .Check("Check");
            INI.CreateEntry("Filename", "Section");

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
                .AddPermission(Sids.Admins, Permissions.Modify)
                .Check("Check");
            Registry.CreateEntry(RegistryKeys.HKU, @"Software\My Company\My Program");
            Run.CreateEntry("FileName")
                .Description("Description")
                .WorkingDir("WorkingDir")
                .StatusMsg("StatusMsg")
                .RunOnceId("RunOnceId")
                .Parameters("Parameters")
                .Verb("Verb")
                .Flags(RunFlags._64bit | RunFlags.RunHidden)
                .Components("Components")
                .Tasks("Tasks")
                .Languages("Languages")
                .MinVersion("MinVersion")
                .OnlyBelowVersion("OnlyBelowVersion")
                .Check("Check");
            Run.CreateEntry("FileName");
            
            UninstallRun.CreateEntry("FileName");
            
            UninstallDelete.CreateEntry(DeleteTypes.Files,"Name")
                .Components("Components")
                .Tasks("Tasks")
                .Languages("Languages")
                .MinVersion("MinVersion")
                .OnlyBelowVersion("OnlyBelowVersion")
                .Check("Check");
            UninstallDelete.CreateEntry(DeleteTypes.Files,"Name");
            InstallDelete.CreateEntry(DeleteTypes.Files,"Name");

            Messages.CreateEntry()
                .Parameter("NextButton", "&Forward");
            
            CustomMessages.CreateEntry()
                .Parameter("NextButton", "&Forward");

            Sections.CreateParameterSection("UnimplementedParameterSection")
                .CreateEntry()
                .Parameter("Root", RegistryKeys.HKU)
                .Parameter("Subkey", @"Software\My Company\My Program")
                .Parameter("ValueName", "Name")
                .Parameter("ValueType", ValueTypes.String)
                .Parameter("ValueData", "Test app");

            Sections.CreateKeyValueSection("UnimplementedKeyValueSection")
                .CreateEntry()
                .Parameter("BeveledLabel", @"Inno Setup")
                .Parameter("HelpTextNote", @"/PORTABLE=1%nEnable portable mode.");

            Code.CreateEntry("script");
        }
    }
}