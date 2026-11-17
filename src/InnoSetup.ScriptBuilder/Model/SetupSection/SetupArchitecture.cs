namespace InnoSetup.ScriptBuilder;

/// <summary>
/// Specifies the architecture of the Setup program itself, as set by the <c>SetupArchitecture</c> directive.
/// Added in Inno Setup 7.0.
/// See
/// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_setuparchitecture">SetupArchitecture</a>.
/// </summary>
public enum SetupArchitecture
{
    /// <summary>
    /// A 32-bit Setup is used, which runs on x86 Windows, x64 Windows and on Arm64 Windows 10 and 11
    /// through emulation. This is the default.
    /// </summary>
    X86,

    /// <summary>
    /// A 64-bit Setup is used, which runs on x64 Windows and on Arm64-based Windows 11 through emulation.
    /// </summary>
    X64
}