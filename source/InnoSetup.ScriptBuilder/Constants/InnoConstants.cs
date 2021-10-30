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

        /// <summary>
        /// The path to the Start Menu folder, as selected by the user on Setup's Select Start Menu Folder wizard page. This folder is created in the All Users profile unless the installation is running in non administrative install mode, in which case it is created in the current user's profile.
        /// </summary>
        public const string Group = "{group}";

        /// <summary>
        /// The path to the current user's local (non-roaming) Application Data folder.
        /// </summary>
        public const string LocalAppData = "{localappdata}";

        /// <summary>
        /// The path to the Application Data folder.
        /// </summary>
        public const string UserAppData = "{userappdata}";

        /// <summary>
        /// The path to the Application Data folder.
        /// </summary>
        public const string CommonAppData = "{commonappdata}";

        /// <summary>
        /// The path to the current user's Common Files directory. Only Windows 7 and later supports {usercf}; if used on previous Windows versions, it will translate to the same directory as {localappdata}\Programs\Common.
        /// </summary>
        public const string UserCommonFiles = "{usercf}";

        /// <summary>
        /// The path to the desktop folder.
        /// </summary>
        public const string CommonDesktop = "{commondesktop}";

        /// <summary>
        /// The path to the desktop folder.
        /// </summary>
        public const string UserDesktop = "{userdesktop}";

        /// <summary>
        /// The path to the My Documents folder.
        /// </summary>
        public const string CommonDocs = "{commondocs}";

        /// <summary>
        /// The path to the My Documents folder.
        /// </summary>
        public const string UserDocs = "{userdocs}";

        /// <summary>
        /// The path to the current user's Favorites folder. (There is no common Favorites folder.)
        /// </summary>
        public const string UserFavorites = "{userfavorites}";

        /// <summary>
        /// The path to the current user's Fonts folder. Only Windows 10 Version 1803 and later supports {userfonts}. Same directory as {localappdata}\Microsoft\Windows\Fonts.
        /// </summary>
        public const string UserFonts = "{userfonts}";

        /// <summary>
        /// The path to the current user's Program Files directory. Only Windows 7 and later supports {userpf}; if used on previous Windows versions, it will translate to the same directory as {localappdata}\Programs.
        /// </summary>
        public const string UserProgramFiles = "{userpf}";

        /// <summary>
        /// The path to the Programs folder on the Start Menu.
        /// </summary>
        public const string CommonPrograms = "{commonprograms}";

        /// <summary>
        /// The path to the Programs folder on the Start Menu.
        /// </summary>
        public const string UserPrograms = "{userprograms}";

        /// <summary>
        /// The path to the current user's Saved Games directory.
        /// </summary>
        public const string UserSavedGames = "{usersavedgames}";

        /// <summary>
        /// The path to the current user's Send To folder. (There is no common Send To folder.)
        /// </summary>
        public const string UserSendTo = "{usersendto}";

        /// <summary>
        /// The path to the top level of the Start Menu.
        /// </summary>
        public const string CommonStartMenu = "{commonstartmenu}";

        /// <summary>
        /// The path to the top level of the Start Menu.
        /// </summary>
        public const string UserStartMenu = "{userstartmenu}";

        /// <summary>
        /// The path to the Startup folder on the Start Menu.
        /// </summary>
        public const string CommonStartup = "{commonstartup}";

        /// <summary>
        /// The path to the Startup folder on the Start Menu.
        /// </summary>
        public const string UserStartup = "{userstartup}";

        /// <summary>
        /// The path to the Templates folder.
        /// </summary>
        public const string CommonTemplates = "{commontemplates}";

        /// <summary>
        /// The path to the Templates folder.
        /// </summary>
        public const string UserTemplates = "{usertemplates}";
    }
}