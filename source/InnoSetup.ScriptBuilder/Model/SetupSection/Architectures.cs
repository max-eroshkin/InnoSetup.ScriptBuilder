namespace InnoSetup.ScriptBuilder
{
    using System;

    [Flags]
    public enum Architectures
    {
        /// <summary>
        /// Matches systems capable of running 32-bit Arm binaries. Only Arm64 Windows includes such support.
        /// </summary>
        Arm32Compatible = 1,

        /// <summary>
        /// Matches systems running Arm64 Windows.
        /// </summary>
        Arm64 = 1 << 1,

        /// <summary>
        /// Matches systems running 64-bit Windows, regardless of OS architecture.
        /// <remarks>
        /// This may be useful in an installer that doesn't ship any architecture-specific binaries,
        /// but requires access to something 64-bit, like HKLM64 in the [Registry] section,
        /// or the native 64-bit Program Files directory.
        /// </remarks>
        /// </summary>
        Win64 = 1 << 2,

        /// <summary>
        /// Matches systems capable of running x64 binaries.
        /// This includes systems running x64 Windows, and also Arm64-based Windows 11 systems,
        /// which have the ability to run x64 binaries via emulation.
        /// </summary>
        X64Compatible = 1 << 3,

        /// <summary>
        /// Matches systems running x64 Windows only — not any other systems that have the ability to run x64 binaries via emulation.
        /// <remarks>
        /// In most cases, x64compatible should be used instead of x64os, because x64compatible allows x64 apps
        /// to be installed on Arm64 Windows 11 systems as well.
        /// However, x64os is appropriate in unusual cases where an x64 app/binary is known to require true x64 Windows
        /// and cannot function under emulation. x64 device drivers are one example; x64 emulation isn't supported
        /// in kernel mode.
        ///
        /// Before Inno Setup 6.3, x64os was named x64. The compiler still accepts x64 as an alias for x64os,
        /// but will emit a deprecation warning when used.
        /// </remarks>
        /// </summary>
        X64Os = 1 << 4,

        /// <summary>
        /// Matches systems capable of running 32-bit x86 binaries. This includes systems running x86 Windows,
        /// x64 Windows, and also Arm64 Windows 10 and 11 systems, which have the ability
        /// to run x86 binaries via emulation.
        /// <remarks>
        /// Given that Setup itself is currently always built as a 32-bit x86 binary, this always matches.
        /// </remarks>
        /// </summary>
        X86Compatible = 1 << 5,

        /// <summary>
        /// Matches systems running 32-bit x86 Windows only.
        /// <remarks>
        /// x86os usually only makes sense when installing 32-bit x86 device drivers.
        /// When installing a regular 32-bit app, x86compatible should be used instead
        /// (or just leave ArchitecturesAllowed unset).
        ///
        /// Before Inno Setup 6.3, x86os was named x86. The compiler still accepts x86 as an alias for x86os.
        /// </remarks>
        /// </summary>
        X86Os = 1 << 6,
    }
}