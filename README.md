# InnoSetup.ScriptBuilder

[![CI](https://github.com/ReactiveBIM/InnoSetup.ScriptBuilder/actions/workflows/CI.yml/badge.svg)](https://github.com/ReactiveBIM/InnoSetup.ScriptBuilder/actions)
[![NuGet](https://img.shields.io/nuget/v/InnoSetup.ScriptBuilder?logo=nuget&label=nuget)](https://www.nuget.org/packages/InnoSetup.ScriptBuilder)
[![Downloads count](https://img.shields.io/nuget/dt/InnoSetup.ScriptBuilder?logo=nuget)](https://www.nuget.org/packages/InnoSetup.ScriptBuilder/absoluteLatest)

This package is intended to build Inno Setup script files (*.iss)
using C# fluent API. You can find the official Inno Setup documentation on [Inno Setup web site](https://jrsoftware.org/ishelp/).

## Installation
.NET CLI
```ps1
dotnet add package InnoSetup.ScriptBuilder
```
Package Manager
```ps1
Install-Package InnoSetup.ScriptBuilder
```

## Examples
### Create builder
To get the script looking like this
```iss
[Setup]
AppName=BimTools.Support
AppVersion=1.2.5.1634640046
DefaultDirName={userappdata}\SupportTools
PrivilegesRequired=lowest
OutputBaseFilename=Tools.Support_2021_1.2.5.1634640046
SetupIconFile=ToolsIcon.ico
UninstallDisplayIcon=ToolsIcon.ico
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
## Directives
You can insert preprocessor directives at the beginning of your script using `Directives` section
```cs
Directives
    .Define("MyAppName", "My Program")
    .Include(@"c:\dir\file.iss")
    .Include("<file.iss>")
    .FreeText(";comments")
    .Undef("var1");
```
Where `FreeText()` allows to insert any text to the script as is.

## Not implemented sections and parameters
If the section you want to insert is not implemented you can use either `Sections.CreateKeyValueSection()`
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