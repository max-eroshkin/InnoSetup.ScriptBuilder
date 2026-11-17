namespace InnoSetup.ScriptBuilder;

/// <summary>
/// Specifies which type of Setup to create, as set by the <c>UseSetupLdr</c> directive. The
/// <see cref="X86"/> and <see cref="X64"/> members were added in Inno Setup 6.7.
/// See
/// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_usesetupldr">UseSetupLdr</a>.
/// </summary>
public enum SetupLdrMode
{
    /// <summary>
    /// The setup data is compiled into at least three files (<c>Setup.exe</c>, <c>Setup-0.bin</c> and
    /// <c>Setup-1.bin</c>) instead of a single EXE, and no Setup Loader is used.
    /// </summary>
    No,

    /// <summary>
    /// A 32-bit Setup Loader is used, which runs on x86 Windows, x64 Windows and on Arm64 Windows 10 and 11
    /// through emulation. Equivalent to <see cref="X86"/>.
    /// </summary>
    Yes,

    /// <summary>
    /// A 32-bit Setup Loader is used, which runs on x86 Windows, x64 Windows and on Arm64 Windows 10 and 11
    /// through emulation.
    /// </summary>
    X86,

    /// <summary>
    /// A 64-bit Setup Loader is used, which runs on x64 Windows and on Arm64-based Windows 11 through
    /// emulation. The resulting installer no longer loads on systems running x86 Windows.
    /// </summary>
    X64
}