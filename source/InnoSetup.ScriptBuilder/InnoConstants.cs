namespace InnoSetup.ScriptBuilder
{
    public static class InnoConstants
    {
        /// <summary>
        /// The application directory, which the user selects on the Select Destination Location page of the wizard.
        /// </summary>
        /// <example>
        /// If you used {app}\MYPROG.EXE on an entry and the user selected "C:\MYPROG" as the application directory, Setup will translate it to "C:\MYPROG\MYPROG.EXE".
        /// </example>
        public const string App = "{app}";

        /// <summary>
        /// The system's Windows directory.
        /// </summary>
        /// <example>
        /// If you used {win}\MYPROG.INI on an entry and the system's Windows directory is "C:\WINDOWS", Setup or Uninstall will translate it to "C:\WINDOWS\MYPROG.INI".
        /// </example>
        public const string Win = "{win}";

        /// <summary>
        /// The system's System32 directory.
        /// </summary>
        /// <example>
        /// If you used {sys}\CTL3D32.DLL on an entry and the system's Windows System directory is "C:\WINDOWS\SYSTEM", Setup or Uninstall will translate it to "C:\WINDOWS\SYSTEM\CTL3D32.DLL".
        /// </example>
        /// <remarks>
        /// On 64-bit Windows, by default, the System32 path returned by this constant maps to the directory containing 32-bit system files, just like on 32-bit Windows. (This can be overridden by enabling 64-bit install mode.)
        /// </remarks>
        public const string Sys = "{sys}";

        /// <summary>
        /// On 64-bit Windows, the directory containing 64-bit system files. On 32-bit Windows, the directory containing 32-bit system files.
        /// </summary>
        /// <example>
        /// 
        /// </example>
        public const string SysNative = "{sysnative}";


        /// <summary>
        /// On 64-bit Windows, the system's SysWOW64 directory, typically "C:\WINDOWS\SysWOW64". This is the actual directory in which 32-bit system files reside. On 32-bit Windows, 32-bit system files do not reside in a separate SysWOW64 directory, so this constant will resolve to the same directory as {sys} if used there.
        /// </summary>
        /// <remarks>
        /// Do not use this constant unless you have a specific need to obtain the name of the actual directory in which 32-bit system files reside. Gratuitously using {syswow64} in places where {sys} will suffice may cause problems. (See the documentation for the [Files] section's sharedfile flag for one example.)
        /// </remarks>>
        public const string SysWow64 = "{syswow64}";


        /// <summary>
        /// The directory in which the Setup files are located.
        /// </summary>
        /// <example>
        /// f you used {src}\MYPROG.EXE on an entry and the user is installing from "S:\", Setup will translate it to "S:\MYPROG.EXE".
        /// </example>
        public const string Src = "{src}";


        /// <summary>
        /// System Drive. The drive Windows is installed on, typically "C:". This directory constant is equivalent to the SystemDrive environment variable.
        /// </summary>
        public const string SystemDrive = "{sd}";

        /// <summary>
        /// Program Files. The path of the system's Program Files directory. {commonpf} is equivalent to {commonpf32} unless the install is running in 64-bit install mode, in which case it is equivalent to {commonpf64}.
        /// </summary>
        public const string ProgramFiles = "{commonpf}";


        /// <summary>
        /// 32-bit Program Files. The path of the system's 32-bit Program Files directory, typically "C:\Program Files" on 32-bit Windows and "C:\Program Files (x86)" on 64-bit Windows.
        /// </summary>
        public const string ProgramFiles32 = "{commonpf32}";

        /// <summary>
        /// 64-bit Windows only: 64-bit Program Files. The path of the system's 64-bit Program Files directory, typically "C:\Program Files". An exception will be raised if an attempt is made to expand this constant on 32-bit Windows.
        /// </summary>
        public const string ProgramFiles64 = "{commonpf64}";

        /// <summary>
        /// Common Files. The path of the system's Common Files directory. {commoncf} is equivalent to {commoncf32} unless the install is running in 64-bit install mode, in which case it is equivalent to {commoncf64}.
        /// </summary>
        public const string CommonFiles = "{commoncf}";

        /// <summary>
        /// 32-bit Common Files. The path of the system's 32-bit Common Files directory, typically "C:\Program Files\Common Files" on 32-bit Windows and "C:\Program Files (x86)\Common Files" on 64-bit Windows.
        /// </summary>
        public const string CommonFiles32 = "{commoncf32}";


        /// <summary>
        /// 64-bit Windows only: 64-bit Common Files. The path of the system's 64-bit Common Files directory, typically "C:\Program Files\Common Files". An exception will be raised if an attempt is made to expand this constant on 32-bit Windows.
        /// </summary>
        public const string CommonFiles64 = "{commoncf64}";

        /// <summary>
        /// Temporary directory used by Setup or Uninstall. This is not the value of the user's TEMP environment variable. It is a subdirectory of the user's temporary directory which is created by Setup or Uninstall at startup (with a name like "C:\WINDOWS\TEMP\IS-xxxxx.tmp"). All files and subdirectories in this directory are deleted when Setup or Uninstall exits. During Setup, this is primarily useful for extracting files that are to be executed in the [Run] section but aren't needed after the installation.
        /// </summary>
        public const string TempDir = "{tmp}";

        /// <summary>
        /// Fonts directory. Normally named "Fonts" under the Windows directory.
        /// </summary>
        public const string FontsDir = "{commonfonts}";

        /// <summary>
        /// DAO directory. This is equivalent to {commoncf}\Microsoft Shared\DAO.
        /// </summary>
        public const string DaoDir = "{dao}";

        /// <summary>
        /// 32-bit .NET Framework version 1.1 install root directory.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 1.1 present.
        /// </remarks>
        public const string Dotnet11 = "{dotnet11}";

        /// <summary>
        /// .NET Framework version 2.0-3.5 install root directory. {dotnet20} is equivalent to {dotnet2032} unless the install is running in 64-bit install mode, in which case it is equivalent to {dotnet2064}.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 2.0-3.5 present.
        /// </remarks>
        public const string Dotnet20 = "{dotnet20}";

        /// <summary>
        /// 32-bit .NET Framework version 2.0-3.5 install root directory.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 2.0-3.5 present.
        /// </remarks>
        public const string Dotnet2032 = "{dotnet2032}";

        /// <summary>
        /// 64-bit Windows only: 64-bit .NET Framework version 2.0-3.5 install root directory.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 2.0-3.5 present.
        /// </remarks>
        public const string Dotnet2064 = "{dotnet2064}";

        /// <summary>
        /// .NET Framework version 4.0 and later install root directory. {dotnet40} is equivalent to {dotnet4032} unless the install is running in 64-bit install mode, in which case it is equivalent to {dotnet4064}.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 4.0 or later present.
        /// Also see IsDotNetInstalled.
        /// </remarks>
        public const string Dotnet40 = "{dotnet40}";

        /// <summary>
        /// 32-bit .NET Framework version 4.0 and later install root directory.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 4.0 or later present.
        /// </remarks>
        public const string Dotnet4032 = "{dotnet4032}";

        /// <summary>
        /// 64-bit Windows only: 64-bit .NET Framework version 4.0 and later install root directory.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 4.0 or later present.*/
        /// </remarks>
        public const string Dotnet4064 = "{dotnet4064}";
    }
}