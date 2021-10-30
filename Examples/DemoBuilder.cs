namespace Examples
{
    using InnoSetup.ScriptBuilder;
    using InnoSetup.ScriptBuilder.Model.SetupSection;

    public class DemoBuilder : IssBuilder
    {
        public DemoBuilder()
        {
            Setup.Create("BimTools.Support")
                .AppVersion("1.2.5.1634640046")
                .DefaultDirName(@"{userappdata}\SupportTools")
                .PrivilegesRequired(PrivilegesRequired.Lowest)
                .OutputBaseFilename("Tools.Support_2021_1.2.5.1634640046")
                .SetupIconFile("ToolsIcon.ico")
                .UninstallDisplayIcon("ToolsIcon.ico")
                .DisableDirPage(YesNo.Yes);
        
            Files.CreateEntry(source: @"bin\*", destDir: InnoConstants.App)
                .Flags(FileFlags.IgnoreVersion | FileFlags.RecurseSubdirs);
            Files.CreateEntry(source: "SupportTools.addin", destDir: @"{userappdata}\Autodesk\Revit\Addins\2019");
            Files.CreateEntry(source: @"bin\Fonts\GraphikLCG-Medium.ttf", destDir: @"{autofonts}")
                .FontInstall("Graphik LCG")
                .Flags(FileFlags.OnlyIfDestFileExists | FileFlags.UninsNeverUninstall);
            Files.CreateEntry(source: @"bin\Fonts\GraphikLCG-Regular.ttf", destDir: @"{autofonts}")
                .FontInstall("Graphik LCG")
                .Flags(FileFlags.OnlyIfDestFileExists | FileFlags.UninsNeverUninstall);
        }
    }
}