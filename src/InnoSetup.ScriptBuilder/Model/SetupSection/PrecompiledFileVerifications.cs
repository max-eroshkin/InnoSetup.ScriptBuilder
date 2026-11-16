namespace InnoSetup.ScriptBuilder;

using System;

/// <summary>
/// Specifies the precompiled files whose verification should be skipped, as set by the
/// <c>DisablePrecompiledFileVerifications</c> directive. Combine the members with <c>|</c>.
/// See
/// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_disableprecompiledfileverifications">
/// DisablePrecompiledFileVerifications
/// </a>.
/// </summary>
[Flags]
public enum PrecompiledFileVerifications
{
    /// <summary>
    /// The Setup program files.
    /// </summary>
    Setup = 1,

    /// <summary>
    /// The Setup custom style files.
    /// </summary>
    SetupCustomStyle = 1 << 1,

    /// <summary>
    /// Both <c>SetupLdr.e32</c> and <c>SetupLdr.e64</c>.
    /// </summary>
    SetupLdr = 1 << 2,

    /// <summary>
    /// <c>is7z.dll</c>, <c>is7zxr.dll</c> and <c>is7zxa.dll</c>.
    /// </summary>
    Is7z = 1 << 3,

    /// <summary>
    /// <c>isbunzip.dll</c>.
    /// </summary>
    IsBunzip = 1 << 4,

    /// <summary>
    /// <c>isunzlib.dll</c>.
    /// </summary>
    IsUnzlib = 1 << 5,

    /// <summary>
    /// Both <c>islzma32.exe</c> and <c>islzma64.exe</c>.
    /// </summary>
    IsLzma = 1 << 6
}
