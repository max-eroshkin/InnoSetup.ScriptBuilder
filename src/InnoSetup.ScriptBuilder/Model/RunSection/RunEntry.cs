namespace InnoSetup.ScriptBuilder;

public class RunEntry : CommonParameterSectionEntryBase, IHazComponentsAndTasks
{
    public string Filename { get; set; }

    public string Description { get; set; }

    public string Parameters { get; set; }

    public string WorkingDir { get; set; }

    public string StatusMsg { get; set; }

    public string RunOnceId { get; set; }

    public string Verb { get; set; }

    /// <summary>
    /// The name of a <c>[Code]</c> procedure to be called for each line of the program's output.
    /// Valid only in a <c>[Run]</c> section, must be combined with the <see cref="RunFlags.LogOutput"/> flag.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=runsection">[Run] section</a>.
    /// </summary>
    public string OnLog { get; set; }

    public RunFlags? Flags { get; set; }

    public string Components { get; set; }

    public string Tasks { get; set; }

    public string BeforeInstall { get; set; }

    public string AfterInstall { get; set; }
}