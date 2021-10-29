# InnoSetup.ScriptBuilder

This package is intended to build InnoSetup script files (*.iss) 
using C# fluent API.

![CI](https://github.com/ReactiveBIM/InnoSetup.ScriptBuilder/actions/workflows/CI.yml/badge.svg)
![Nuget](https://img.shields.io/nuget/vpre/InnoSetup.ScriptBuilder?style=flat)

## Getting started
### Create builder
To get the script looking like this
```iss
[Setup]
AppName="BimTools.Support"
AppVersion="1.2.5.1634640046"
DefaultDirName="{userappdata}\SupportTools"
PrivilegesRequired=lowest
OutputBaseFilename="Tools.Support_2021_1.2.5.1634640046"
SetupIconFile="ToolsIcon.ico"
UninstallDisplayIcon="ToolsIcon.ico"
DisableDirPage=yes

[Files]
Source: "bin\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs; 
Source: "SupportTools.addin"; DestDir: "{userappdata}\Autodesk\Revit\Addins\2019"; 
Source: "bin\Fonts\GraphikLCG-Medium.ttf"; DestDir: "{autofonts}"; Flags: onlyifdestfileexists uninsneveruninstall; FontInstall: "Graphik LCG"; 
Source: "bin\Fonts\GraphikLCG-Regular.ttf"; DestDir: "{autofonts}"; Flags: onlyifdestfileexists uninsneveruninstall; FontInstall: "Graphik LCG";
```

inherit your builder class from `IssBuilder` base class
```c#
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
```
or use `BuilderUtils.CreateBuilder()`
```c#
var builder = BuilderUtils.CreateBuilder(builder =>
{
    builder.Setup.Create("BimTools.Support")
        .AppVersion("1.2.5.1634640046")
        .DefaultDirName(@"{userappdata}\SupportTools")
        .PrivilegesRequired(PrivilegesRequired.Lowest)
        .OutputBaseFilename("Tools.Support_2021_1.2.5.1634640046")
        .SetupIconFile("ToolsIcon.ico")
        .UninstallDisplayIcon("ToolsIcon.ico")
        .DisableDirPage(YesNo.Yes);
        
    builder.Files.CreateEntry(source: @"bin\*", destDir: InnoConstants.App)
        .Flags(FileFlags.IgnoreVersion | FileFlags.RecurseSubdirs);
    builder.Files.CreateEntry(source: "SupportTools.addin", destDir: @"{userappdata}\Autodesk\Revit\Addins\2019");
    builder.Files.CreateEntry(source: @"bin\Fonts\GraphikLCG-Medium.ttf", destDir: @"{autofonts}")
        .FontInstall("Graphik LCG")
        .Flags(FileFlags.OnlyIfDestFileExists | FileFlags.UninsNeverUninstall);
    builder.Files.CreateEntry(source: @"bin\Fonts\GraphikLCG-Regular.ttf", destDir: @"{autofonts}")
        .FontInstall("Graphik LCG")
        .Flags(FileFlags.OnlyIfDestFileExists | FileFlags.UninsNeverUninstall);
);
```
## Getting results
### String result
```c#
var builder = new DemoBuilder();
var result = builder.ToString();
```
### Script file
```c#
var builder = new DemoBuilder();
builder.Build("demo.iss");

// or

BuilderUtils.Build<DemoBuilder>("demo.iss");

// or

BuilderUtils.Build(
    builder =>
    {
        builder.Setup.Create("BimTools.Support")
            .AppVersion("1.2.5.1634640046")
            .DefaultDirName(@"{userappdata}\SupportTools");
        builder.Files.CreateEntry(@"bin\*", InnoConstants.App)
            .Flags(FileFlags.IgnoreVersion | FileFlags.RecurseSubdirs);
    }, 
    "demo.iss");
```
## Not implemented sections and parameters
If the section you want to insert is not implemented you can use `Sections.CreateKeyValueSection()`
or `Sections.CreateParameterSection()` methods. 
To insert not implemented parameters/directives of any kind of section use `Parameter()` method.
```c#
// for key-value sections
Sections.CreateKeyValueSection("Messages")
    .CreateEntry()
    .Parameter("BeveledLabel", @"Inno Setup")
    .Parameter("HelpTextNote", @"/PORTABLE=1%nEnable portable mode.");
    
// for parameter sections
Sections.CreateParameterSection("Registry")
    .CreateEntry()
        .Parameter("Root", RegistryKeys.HKU)
        .Parameter("Subkey", @"Software\My Company\My Program")
        .Parameter("ValueName", "Name")
        .Parameter("ValueType", ValueTypes.String)
        .Parameter("ValueData", "Test app");
```
