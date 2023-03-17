using System;
using System.Linq;
using System.Text;
using Bimlab.Nuke.Components;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[UnsetVisualStudioEnvironmentVariables]
[GitHubActions("CI",
    GitHubActionsImage.WindowsLatest,
    FetchDepth = 0,
    OnPushBranches = new[] { DevelopBranch, "feature/**" },
    OnPullRequestBranches = new[] { DevelopBranch, "feature/**" },
    InvokedTargets = new[] { nameof(Test), nameof(IPublish.Publish) },
    ImportSecrets = new[] { "NUGET_API_KEY", "ALL_PACKAGES" })]
[GitHubActions("Publish",
    GitHubActionsImage.WindowsLatest,
    FetchDepth = 0,
    OnPushBranches = new[] { MasterBranch, "release/**" },
    InvokedTargets = new[] { nameof(Test), nameof(IPublish.Publish) },
    ImportSecrets = new[] { "NUGET_API_KEY", "ALL_PACKAGES" })]
partial class Build : NukeBuild, IPublish
{
    const string MasterBranch = "master";
    const string DevelopBranch = "develop";

    [Solution]
    public readonly Solution Solution;

    Solution IHazSolution.Solution => Solution;

    readonly AbsolutePath OutputDir = TemporaryDirectory / "output";
    readonly AbsolutePath IssPath = TemporaryDirectory / "setup.iss";

    [UsedImplicitly]
    public Target Test => _ => _
        .Before<IRestore>()
        .Executes(() =>
        {
            DotNetTest(settings => settings
                .SetProjectFile(Solution.Path)
                .SetConfiguration(From<IHazConfiguration>().Configuration));
        });

    public Build()
    {
        Console.OutputEncoding = Encoding.UTF8;
    }

    static int Main() => Execute<Build>(x => x.BuildSetup);

    public Configure<DotNetPackSettings> PackSettings => _ => _
        .SetProperty("Copyright", $"Copyright ©{DateTime.UtcNow.Year} Reactive BIM");

    T From<T>()
        where T : INukeBuild
        => (T)(object)this;
}