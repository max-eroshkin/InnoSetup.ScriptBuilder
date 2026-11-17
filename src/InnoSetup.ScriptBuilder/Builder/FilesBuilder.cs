namespace InnoSetup.ScriptBuilder;

using System.Collections.Generic;

public class FilesBuilder :
    CommonParameterSectionBuilderBase<FilesBuilder, FileEntry>,
    IFileEntryBuilder,
    IComponentsAndTasksBuilder<FilesBuilder>
{
    public override string SectionName => "Files";

    public FilesBuilder CreateEntry(string source, string destDir)
    {
        CreateEntryInternal();
        Source(source);
        DestDir(destDir);

        return this;
    }

    public FilesBuilder DestName(string value) => SetPropertyValue(value);
    public FilesBuilder Attribs(AttribsFlags value) => SetPropertyValue(value);
    public FilesBuilder FontInstall(string value) => SetPropertyValue(value);
    public FilesBuilder Excludes(string value) => SetPropertyValue(value);
    public FilesBuilder ExternalSize(long value) => SetPropertyValue(value);
    public FilesBuilder StrongAssemblyName(string value) => SetPropertyValue(value);

    /// <summary>
    /// A space separated list of key names or group names from the [ISSigKeys] section, specifying which keys
    /// are allowed for the verification done by the <see cref="FileFlags.ISSigVerify"/> flag.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    public FilesBuilder ISSigAllowedKeys(string value) => SetPropertyValue(value);

    /// <summary>
    /// Instructs the compiler or Setup to do a simple SHA-256 hash check instead of a full signature verification,
    /// as an alternative to using the <see cref="FileFlags.ISSigVerify"/> flag.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    public FilesBuilder Hash(string value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the password of the archive to extract, which can include constants.
    /// Ignored if the <see cref="FileFlags.ExtractArchive"/> flag isn't also specified.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    public FilesBuilder ExtractArchivePassword(string value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the URL of the <c>.issig</c> signature file which should be downloaded, which can include
    /// constants. Ignored if the <see cref="FileFlags.Download"/> and <see cref="FileFlags.ISSigVerify"/> flags
    /// aren't both also specified.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    public FilesBuilder DownloadISSigSource(string value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the basic authentication username to use for the file download, which can include constants.
    /// Ignored if the <see cref="FileFlags.Download"/> flag isn't also specified.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    public FilesBuilder DownloadUserName(string value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the basic authentication password to use for the file download, which can include constants.
    /// Stored in an unencrypted form in the resulting Setup file(s). Ignored if the
    /// <see cref="FileFlags.Download"/> flag isn't also specified.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    public FilesBuilder DownloadPassword(string value) => SetPropertyValue(value);

    public FilesBuilder Flags(FileFlags value) => SetPropertyValue(value);
    public FilesBuilder Components(string value) => SetPropertyValue(value);

    /// <inheritdoc />
    public FilesBuilder BeforeInstall(string value) => SetPropertyValue(value);

    /// <inheritdoc />
    public FilesBuilder AfterInstall(string value) => SetPropertyValue(value);

    public FilesBuilder Tasks(string value) => SetPropertyValue(value);

    public FilesBuilder AddPermission(Sids group, Permissions permission)
    {
        Data.Permissions ??= new List<GroupPermission>();
        Data.Permissions.Add(new GroupPermission(group, permission));
        return this;
    }

    private FilesBuilder Source(string value) => SetPropertyValue(value);
    private FilesBuilder DestDir(string value) => SetPropertyValue(value);
}