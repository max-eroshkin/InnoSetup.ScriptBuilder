using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bimlab.Nuke.Components;
using InnoSetup.ScriptBuilder;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.InnoSetup;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
[GitHubActions("CI",
    GitHubActionsImage.WindowsLatest,
    OnPushBranches = new[] { DevelopBranch },
    OnPullRequestBranches = new[] { DevelopBranch, "feature/**" },
    InvokedTargets = new[] { nameof(Test), nameof(IPublish.Publish) },
    ImportSecrets = new[] { "NUGET_API_KEY", "ALL_PACKAGES" })]
[GitHubActions("Publish",
    GitHubActionsImage.WindowsLatest,
    OnPushBranches = new[] { MasterBranch, "release/**" },
    InvokedTargets = new[] { nameof(Test), nameof(IPublish.Publish) },
    ImportSecrets = new[] { "NUGET_API_KEY", "ALL_PACKAGES" })]
partial class Build : NukeBuild,
    IHazSolution,
    IRestore,
    ICompile,
    IHazGitRepository,
    IPack,
    IPublish
{
    const string MasterBranch = "master";
    const string DevelopBranch = "develop";

    /// <summary>
    /// Solution
    /// </summary>
    [Solution]
    public readonly Solution Solution;

    Solution IHazSolution.Solution => Solution;

    AbsolutePath OutputDir = TemporaryDirectory / "output";
    AbsolutePath IssPath = TemporaryDirectory / "setup.iss";

    [UsedImplicitly]
    Target Clean => _ => _
        .Before<IRestore>()
        .Executes(() =>
        {
            GlobDirectories(Solution.Directory, "**/bin", "**/obj")
                .Where(x => !IsDescendantPath(BuildProjectDirectory, x))
                .ForEach(FileSystemTasks.DeleteDirectory);
        });

    [UsedImplicitly]
    public Target Test => _ => _
        .Before<IRestore>()
        .Executes(() =>
        {
            DotNetTest(settings => settings
                .SetProjectFile(Solution.Path)
                .SetConfiguration(From<IHazConfiguration>().Configuration));
        });

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
    /// Run <code>.\build.cmd build-setup</code> in the solution folder.
    /// </summary>
    public Target BuildSetup => _ => _
        .Description("Builds a Demo app installation package.")
        .DependsOn(PublishDemoApp, BuildScript)
        .Executes(() =>
        {
            InnoSetupTasks.InnoSetup(config => config
                .SetProcessToolPath(ToolPathResolver.GetPackageExecutable("Tools.InnoSetup", "ISCC.exe"))
                .SetScriptFile(IssPath)
                .SetOutputDir(From<IPack>().ArtifactsDirectory));
        });

    Target PublishDemoApp => _ => _
        .Executes(() =>
        {
            DotNetPublish(x => x
                .SetConfiguration(From<IHazConfiguration>().Configuration)
                .SetOutput(OutputDir)
                .SetProject(Solution.GetProject("DemoApp")!.Path));
        });

    public Build()
    {
        Console.OutputEncoding = Encoding.UTF8;
    }

    static int Main() => Execute<Build>(x => x.From<IPublish>().List);

   
    public Configure<DotNetPackSettings> PackSettings => _ => _
        .SetProperty("Copyright", $"Copyright ©{DateTime.UtcNow.Year} Reactive BIM");

    T From<T>()
        where T : INukeBuild
        => (T)(object)this;
}