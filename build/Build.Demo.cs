using System;
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
            var programFiles = (RelativePath)InnoConstants.ProgramFiles64;
            var group = (RelativePath)InnoConstants.Group;
            var appDir = (RelativePath)InnoConstants.App;

            BuilderUtils.Build(builder =>
            {
                var now = DateTime.UtcNow;
                builder.Setup.Create("InnoSetup.ScriptBuilder Demo")
                    .AppId("{{53A6910D-931A-4FD7-AAA3-DA94DCAD62B6}")
                    .AppVersion("1.0.0")
                    .DefaultDirName(programFiles / "IssBuilder Demo")
                    .DefaultGroupName("InnoSetup ScriptBuilder Demo")
                    .OutputBaseFilename($"InnoSetup.Builder.Demo_{now:yyyyMMdd}.{now:hhmm}")
                    .ArchitecturesAllowed(Architectures.X64)
                    .ArchitecturesInstallIn64BitMode(ArchitecturesInstallIn64BitMode.X64)
                    .SolidCompression(YesNo.Yes)
                    .Compression("lzma2")
                    .DisableDirPage(YesNo.No)
                    .DisableProgramGroupPage(YesNo.No);

                builder.Files
                    .CreateEntry(OutputDir / "*", InnoConstants.App)
                    .Flags(FileFlags.IgnoreVersion | FileFlags.RecurseSubdirs);

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
                .SetProcessToolPath(ToolPathResolver.GetPackageExecutable("Tools.InnoSetup", "ISCC.exe"))
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