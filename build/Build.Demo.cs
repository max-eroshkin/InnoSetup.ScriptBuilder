﻿using System;
using System.IO;
using Bimlab.Nuke.Components;
using InnoSetup.ScriptBuilder;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.InnoSetup;

partial class Build
{
    Target BuildScript => _ => _
        .Description("Builds an iss script file.")
        .Executes(() =>
        {
            var programFiles = (RelativePath)InnoConstants.Directories.ProgramFiles64;
            var group = (RelativePath)InnoConstants.Shell.Group;
            var appDir = (RelativePath)InnoConstants.Directories.App;

            BuilderUtils.Build(builder =>
            {
                var now = DateTime.UtcNow;
                builder.Setup.Create("InnoSetup.ScriptBuilder Demo")
                    .AppId("{{53A6910D-931A-4FD7-AAA3-DA94DCAD62B6}")
                    .AppVersion("1.0.0")
                    .DefaultDirName(programFiles / "IssBuilder Demo")
                    .DefaultGroupName("InnoSetup ScriptBuilder Demo")
                    .OutputBaseFilename($"InnoSetup.Builder.Demo_{now:yyyyMMdd}.{now:hhmm}")
                    .ArchitecturesAllowed(Architectures.X64Os)
                    .ArchitecturesInstallIn64BitMode(ArchitecturesInstallIn64BitMode.X64Os)
                    .SolidCompression(YesNo.Yes)
                    .Compression("lzma2")
                    .DisableDirPage(YesNo.No)
                    .DisableProgramGroupPage(YesNo.No);

                builder.Files
                    .CreateEntry(OutputDir / "*", InnoConstants.Directories.App)
                    .Flags(FileFlags.IgnoreVersion | FileFlags.RecurseSubdirs);
                
                builder.Registry
                    .CreateEntry(RegistryKeys.HKCU, @"SOFTWARE\Microsoft\Windows\CurrentVersion\InnoSetupDemoApp")
                    .ValueName("DemoAppData")
                    .ValueType(ValueTypes.String)
                    .ValueData("Test Data")
                    .Flags(RegistryFlags.UninsDeleteKey);

                builder.Icons
                    .CreateEntry(group / "InnoSetup.ScriptBuilder Demo", appDir / "DemoApp.exe");

                builder.Code.CreateEntry(File.ReadAllText(RootDirectory / "build" / "setup.pas"));
            }, IssPath);

            Console.WriteLine(File.ReadAllText(IssPath));
        });

    /// <summary>
    /// Run <code>.\build.cmd</code> in the solution folder to build Demo setup.
    /// </summary>
    Target BuildSetup => _ => _
        .Description("Builds Demo application installation package.")
        .DependsOn(PublishDemoApp, BuildScript)
        .Executes(() =>
        {
            InnoSetupTasks.InnoSetup(config => config
                .SetProcessToolPath(NuGetToolPathResolver.GetPackageExecutable("Tools.InnoSetup", "ISCC.exe", "6.3.1"))
                .SetScriptFile(IssPath)
                .SetOutputDir(From<IPack>().ArtifactsDirectory));
        });

    Target PublishDemoApp => _ => _
        .Description("Publishes Demo application.")
        .Executes(() =>
        {
            DotNetTasks.DotNetPublish(x => x
                .SetConfiguration("Release")
                .SetOutput(OutputDir)
                .SetProject(Solution.GetProject("DemoApp")!.Path));
        });
}