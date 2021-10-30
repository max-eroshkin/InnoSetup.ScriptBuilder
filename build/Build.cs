using System;
using System.Linq;
using System.Text;
using Bimlab.Nuke.Components;
using InnoSetup.ScriptBuilder;
using InnoSetup.ScriptBuilder.Model.SetupSection;
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
        .Before(Clean)
        .Executes(() =>
        {
            DotNetTest(settings => settings
                .SetProjectFile(Solution.Path)
                .SetConfiguration(From<IHazConfiguration>().Configuration));
        });

    public Target Inno => _ => _
        .DependsOn<ICompile>()
        .Executes(() =>
        {
            var iss = TemporaryDirectory / "package.iss";
            var userdata = (RelativePath)"{userappdata}";
            var outDir = Solution.GetProject("InnoSetup.ScriptBuilder").Directory / "bin" /
                From<IHazConfiguration>().Configuration / "netstandard2.0";
            
            BuilderUtils.Build(s =>
            {
                var now = DateTime.UtcNow;
                s.Setup.Create("InnoSetup Script Builder")
                    .AppVersion("0.1.0")
                    .DefaultDirName( userdata / "IssBuilder")
                    .PrivilegesRequired(PrivilegesRequired.Lowest)
                    .OutputBaseFilename($"InnoSetup.Builder_{now:yyyyMMdd}.{now:hhmm}")
                    .DisableDirPage(YesNo.Yes);
                s.Files
                    .CreateEntry(outDir / "*", InnoConstants.App).Flags(FileFlags.IgnoreVersion | FileFlags.RecurseSubdirs);
            }, iss);
            
            InnoSetupTasks.InnoSetup(config => config
                .SetProcessToolPath(ToolPathResolver.GetPackageExecutable("Tools.InnoSetup", "ISCC.exe"))
                .SetScriptFile(iss)
                .SetOutputDir(From<IPack>().ArtifactsDirectory));
        });
    
    public Build()
    {
        Console.OutputEncoding = Encoding.UTF8;
    }

    static int Main() => Execute<Build>(x => x.From<IPublish>().List);

    T From<T>()
        where T : INukeBuild
        => (T)(object)this;
}