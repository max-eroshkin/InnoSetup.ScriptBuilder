namespace InnoSetup.ScriptBuilder;

using System.Collections.Generic;

public class FileEntry : CommonParameterSectionEntryBase, IHazComponentsAndTasks
{
    public string Source { get; set; }

    public string DestDir { get; set; }

    public string DestName { get; set; }

    public AttribsFlags? Attribs { get; set; }

    public string FontInstall { get; set; }

    public string Excludes { get; set; }

    public long? ExternalSize { get; set; }

    public string StrongAssemblyName { get; set; }

    /// <summary>
    /// A space separated list of key names or group names from the [ISSigKeys] section, specifying which keys
    /// are allowed for the verification done by the <c>issigverify</c> flag.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    public string ISSigAllowedKeys { get; set; }

    /// <summary>
    /// Instructs the compiler or Setup to do a simple SHA-256 hash check instead of a full signature verification,
    /// as an alternative to using the <c>issigverify</c> flag.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    public string Hash { get; set; }

    /// <summary>
    /// Specifies the password of the archive to extract, which can include constants.
    /// Ignored if the <c>extractarchive</c> flag isn't also specified.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    public string ExtractArchivePassword { get; set; }

    /// <summary>
    /// Specifies the URL of the <c>.issig</c> signature file which should be downloaded, which can include
    /// constants. Ignored if the <c>download</c> and <c>issigverify</c> flags aren't both also specified.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    public string DownloadISSigSource { get; set; }

    /// <summary>
    /// Specifies the basic authentication username to use for the file download, which can include constants.
    /// Ignored if the <c>download</c> flag isn't also specified.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    public string DownloadUserName { get; set; }

    /// <summary>
    /// Specifies the basic authentication password to use for the file download, which can include constants.
    /// Stored in an unencrypted form in the resulting Setup file(s). Ignored if the <c>download</c> flag isn't
    /// also specified.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    public string DownloadPassword { get; set; }

    public List<GroupPermission> Permissions { get; set; }

    public FileFlags? Flags { get; set; }

    public string Components { get; set; }

    public string Tasks { get; set; }

    public string BeforeInstall { get; set; }

    public string AfterInstall { get; set; }
}