using InnoSetup.ScriptBuilder;

namespace BuilderTests
{
    using InnoSetup.ScriptBuilder.Model;
    using InnoSetup.ScriptBuilder.Model.ComponentSection;
    using InnoSetup.ScriptBuilder.Model.FileSection;
    using InnoSetup.ScriptBuilder.Model.RegistrySection;
    using InnoSetup.ScriptBuilder.Model.SetupSection;

    public class TestScriptBuilderBuilder : IssBuilder
    {
        public TestScriptBuilderBuilder()
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
            
            Files.CreateEntry(source: @"bin\*", destDir: InnoConstants.App)
                .Flags(FileFlags.IgnoreVersion | FileFlags.RecurseSubdirs);
            Files.CreateEntry(source: @"bin\fsfsa", destDir: InnoConstants.App)
                .Flags(FileFlags.IgnoreVersion | FileFlags.RecurseSubdirs)
                .Parameter("AuxParameter1", "123", false)
                .Parameter("AuxParameter2", "123-6", true)
                .Parameter("AuxParameter3", Sids.System);
            Files.CreateEntry(source: "SupportTools.addin", destDir: @"{userappdata}\Autodesk\Revit\Addins\2019");
            Files.CreateEntry(source: @"bin\Fonts\GraphikLCG-Medium.ttf", destDir: @"{autofonts}")
                .FontInstall("Graphik LCG")
                .Flags(FileFlags.OnlyIfDestFileExists | FileFlags.UninsNeverUninstall);
            Files.CreateEntry(source: @"bin\Fonts\GraphikLCG-Regular.ttf", destDir: @"{autofonts}")
                .FontInstall("Graphik LCG")
                .Flags(FileFlags.OnlyIfDestFileExists | FileFlags.UninsNeverUninstall);
            Files.CreateEntry(source: @"bin\Fonts\GraphikLCG-gfjfjfj.ttf", destDir: @"{autofonts}")
                .FontInstall("Graphik 111")
                .AddPermission(Sids.System, Permissions.ReadExec)
                .AddPermission(Sids.Users, Permissions.Modify)
                .Flags(FileFlags.OnlyIfDestFileExists | FileFlags.UninsNeverUninstall);

            Components
                .CreateEntry("main", "Main Files").Types("full compact custom").Flags(ComponentFlags.Fixed);

            Registry.CreateEntry(RegistryKeys.Hku, @"Software\My Company\My Program")
                .ValueName("Name").ValueType(ValueTypes.String).ValueData("Test app");

            Sections.CreateParameterSection("Registry")
                .CreateEntry().Parameter("Version", "123.56", false).Parameter("Component", "main");

            Sections.CreateKeyValueSection("Messages")
                .CreateEntry()
                .Parameter("BeveledLabel", @"Inno Setup")
                .Parameter("HelpTextNote", @"/PORTABLE=1%nEnable portable mode.");
        }
    }
}