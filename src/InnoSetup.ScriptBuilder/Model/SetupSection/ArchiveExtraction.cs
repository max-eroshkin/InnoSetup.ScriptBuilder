namespace InnoSetup.ScriptBuilder;

/// <summary>
/// Specifies the method of archive extraction used by the <see cref="FileFlags.ExtractArchive"/> flag and by
/// the <c>ExtractArchive</c> support function.
/// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_archiveextraction">ArchiveExtraction</a>.
/// </summary>
public enum ArchiveExtraction
{
    /// <summary>
    /// Lets the compiler select the appropriate method based on the entries of the <c>[Files]</c> section.
    /// </summary>
    Auto,

    /// <summary>
    /// Uses an embedded version of the "7z ANSI-C Decoder"; only supports <c>.7z</c> archives that are not
    /// password-protected.
    /// </summary>
    Basic,

    /// <summary>
    /// Uses <c>is7zxr.dll</c>; only supports <c>.7z</c> archives that are not password-protected.
    /// </summary>
    [IssValue("enhanced/nopassword")] EnhancedNoPassword,

    /// <summary>
    /// Uses <c>is7zxa.dll</c>; only supports <c>.7z</c> archives, which may be password-protected.
    /// </summary>
    Enhanced,

    /// <summary>
    /// Uses <c>is7z.dll</c>; supports multiple archive formats and multi-volume archives.
    /// </summary>
    Full
}