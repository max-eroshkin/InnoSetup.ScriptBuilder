namespace InnoSetup.ScriptBuilder
{
    using System;

    /// <summary>
    /// Contains <a href="https://jrsoftware.org/ishelp/index.php?topic=consts">Inno Setup constants.</a>
    /// </summary>
    public static class InnoConstants
    {
        /// <summary>
        /// The application directory, which the user selects on the Select Destination Location page of the wizard.
        /// </summary>
        /// <example>
        /// If you used {app}\MYPROG.EXE on an entry and the user selected "C:\MYPROG" as the application directory, Setup will translate it to "C:\MYPROG\MYPROG.EXE".
        /// </example>
        [Obsolete("Use InnoConstants.Directories.App")]
        public const string App = "{app}";

        /// <summary>
        /// The system's Windows directory.
        /// </summary>
        /// <example>
        /// If you used {win}\MYPROG.INI on an entry and the system's Windows directory is "C:\WINDOWS", Setup or Uninstall will translate it to "C:\WINDOWS\MYPROG.INI".
        /// </example>
        [Obsolete("Use InnoConstants.Directories.Win")]
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
        [Obsolete("Use InnoConstants.Directories.Sys")]
        public const string Sys = "{sys}";

        /// <summary>
        /// On 64-bit Windows, the directory containing 64-bit system files. On 32-bit Windows, the directory containing 32-bit system files.
        /// </summary>
        [Obsolete("Use InnoConstants.Directories.SysNative")]
        public const string SysNative = "{sysnative}";

        /// <summary>
        /// On 64-bit Windows, the system's SysWOW64 directory, typically "C:\WINDOWS\SysWOW64". This is the actual directory in which 32-bit system files reside. On 32-bit Windows, 32-bit system files do not reside in a separate SysWOW64 directory, so this constant will resolve to the same directory as {sys} if used there.
        /// </summary>
        /// <remarks>
        /// Do not use this constant unless you have a specific need to obtain the name of the actual directory in which 32-bit system files reside. Gratuitously using {syswow64} in places where {sys} will suffice may cause problems. (See the documentation for the [Files] section's sharedfile flag for one example.)
        /// </remarks>>
        [Obsolete("Use InnoConstants.Directories.SysWow64")]
        public const string SysWow64 = "{syswow64}";

        /// <summary>
        /// The directory in which the Setup files are located.
        /// </summary>
        /// <example>
        /// f you used {src}\MYPROG.EXE on an entry and the user is installing from "S:\", Setup will translate it to "S:\MYPROG.EXE".
        /// </example>
        [Obsolete("Use InnoConstants.Directories.Src")]
        public const string Src = "{src}";

        /// <summary>
        /// System Drive. The drive Windows is installed on, typically "C:". This directory constant is equivalent to the SystemDrive environment variable.
        /// </summary>
        [Obsolete("Use InnoConstants.Directories.SystemDrive")]
        public const string SystemDrive = "{sd}";

        /// <summary>
        /// Program Files. The path of the system's Program Files directory. {commonpf} is equivalent to {commonpf32} unless the install is running in 64-bit install mode, in which case it is equivalent to {commonpf64}.
        /// </summary>
        [Obsolete("Use InnoConstants.Directories.ProgramFiles")]
        public const string ProgramFiles = "{commonpf}";

        /// <summary>
        /// 32-bit Program Files. The path of the system's 32-bit Program Files directory, typically "C:\Program Files" on 32-bit Windows and "C:\Program Files (x86)" on 64-bit Windows.
        /// </summary>
        [Obsolete("Use InnoConstants.Directories.ProgramFiles32")]
        public const string ProgramFiles32 = "{commonpf32}";

        /// <summary>
        /// 64-bit Windows only: 64-bit Program Files. The path of the system's 64-bit Program Files directory, typically "C:\Program Files". An exception will be raised if an attempt is made to expand this constant on 32-bit Windows.
        /// </summary>
        [Obsolete("Use InnoConstants.Directories.ProgramFiles64")]
        public const string ProgramFiles64 = "{commonpf64}";

        /// <summary>
        /// Common Files. The path of the system's Common Files directory. {commoncf} is equivalent to {commoncf32} unless the install is running in 64-bit install mode, in which case it is equivalent to {commoncf64}.
        /// </summary>
        [Obsolete("Use InnoConstants.Directories.CommonFiles")]
        public const string CommonFiles = "{commoncf}";

        /// <summary>
        /// 32-bit Common Files. The path of the system's 32-bit Common Files directory, typically "C:\Program Files\Common Files" on 32-bit Windows and "C:\Program Files (x86)\Common Files" on 64-bit Windows.
        /// </summary>
        [Obsolete("Use InnoConstants.Directories.CommonFiles32")]
        public const string CommonFiles32 = "{commoncf32}";

        /// <summary>
        /// 64-bit Windows only: 64-bit Common Files. The path of the system's 64-bit Common Files directory, typically "C:\Program Files\Common Files". An exception will be raised if an attempt is made to expand this constant on 32-bit Windows.
        /// </summary>
        [Obsolete("Use InnoConstants.Directories.CommonFiles64")]
        public const string CommonFiles64 = "{commoncf64}";

        /// <summary>
        /// Temporary directory used by Setup or Uninstall. This is not the value of the user's TEMP environment variable. It is a subdirectory of the user's temporary directory which is created by Setup or Uninstall at startup (with a name like "C:\WINDOWS\TEMP\IS-xxxxx.tmp"). All files and subdirectories in this directory are deleted when Setup or Uninstall exits. During Setup, this is primarily useful for extracting files that are to be executed in the [Run] section but aren't needed after the installation.
        /// </summary>
        [Obsolete("Use InnoConstants.Directories.TempDir")]
        public const string TempDir = "{tmp}";

        /// <summary>
        /// Fonts directory. Normally named "Fonts" under the Windows directory.
        /// </summary>
        [Obsolete("Use InnoConstants.Directories.FontsDir")]
        public const string FontsDir = "{commonfonts}";

        /// <summary>
        /// DAO directory. This is equivalent to {commoncf}\Microsoft Shared\DAO.
        /// </summary>
        [Obsolete("Use InnoConstants.Directories.DaoDir")]
        public const string DaoDir = "{dao}";

        /// <summary>
        /// 32-bit .NET Framework version 1.1 install root directory.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 1.1 present.
        /// </remarks>
        [Obsolete("Use InnoConstants.Directories.Dotnet11")]
        public const string Dotnet11 = "{dotnet11}";

        /// <summary>
        /// .NET Framework version 2.0-3.5 install root directory. {dotnet20} is equivalent to {dotnet2032} unless the install is running in 64-bit install mode, in which case it is equivalent to {dotnet2064}.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 2.0-3.5 present.
        /// </remarks>
        [Obsolete("Use InnoConstants.Directories.Dotnet20")]
        public const string Dotnet20 = "{dotnet20}";

        /// <summary>
        /// 32-bit .NET Framework version 2.0-3.5 install root directory.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 2.0-3.5 present.
        /// </remarks>
        [Obsolete("Use InnoConstants.Directories.Dotnet2032")]
        public const string Dotnet2032 = "{dotnet2032}";

        /// <summary>
        /// 64-bit Windows only: 64-bit .NET Framework version 2.0-3.5 install root directory.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 2.0-3.5 present.
        /// </remarks>
        [Obsolete("Use InnoConstants.Directories.Dotnet2064")]
        public const string Dotnet2064 = "{dotnet2064}";

        /// <summary>
        /// .NET Framework version 4.0 and later install root directory. {dotnet40} is equivalent to {dotnet4032} unless the install is running in 64-bit install mode, in which case it is equivalent to {dotnet4064}.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 4.0 or later present.
        /// Also see IsDotNetInstalled.
        /// </remarks>
        [Obsolete("Use InnoConstants.Directories.Dotnet40")]
        public const string Dotnet40 = "{dotnet40}";

        /// <summary>
        /// 32-bit .NET Framework version 4.0 and later install root directory.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system with no .NET Framework version 4.0 or later present.
        /// </remarks>
        [Obsolete("Use InnoConstants.Directories.Dotnet4032")]
        public const string Dotnet4032 = "{dotnet4032}";

        /// <summary>
        /// 64-bit Windows only: 64-bit .NET Framework version 4.0 and later install root directory.
        /// </summary>
        /// <remarks>
        /// An exception will be raised if an attempt is made to expand this constant on a system
        /// with no .NET Framework version 4.0 or later present.*/
        /// </remarks>
        [Obsolete("Use InnoConstants.Directories.Dotnet4064")]
        public const string Dotnet4064 = "{dotnet4064}";

        /// <summary>
        /// The path to the Start Menu folder, as selected by the user on Setup's Select Start Menu Folder wizard page.
        /// This folder is created in the All Users profile unless the installation is running in non administrative
        /// install mode, in which case it is created in the current user's profile.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.Group")]
        public const string Group = "{group}";

        /// <summary>
        /// The path to the current user's local (non-roaming) Application Data folder.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.LocalAppData")]
        public const string LocalAppData = "{localappdata}";

        /// <summary>
        /// The path to the Application Data folder.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserAppData")]
        public const string UserAppData = "{userappdata}";

        /// <summary>
        /// The path to the Application Data folder.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.CommonAppData")]
        public const string CommonAppData = "{commonappdata}";

        /// <summary>
        /// The path to the current user's Common Files directory. Only Windows 7 and later supports {usercf}; if used on previous Windows versions, it will translate to the same directory as {localappdata}\Programs\Common.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserCommonFiles")]
        public const string UserCommonFiles = "{usercf}";

        /// <summary>
        /// The path to the desktop folder.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.CommonDesktop")]
        public const string CommonDesktop = "{commondesktop}";

        /// <summary>
        /// The path to the desktop folder.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserDesktop")]
        public const string UserDesktop = "{userdesktop}";

        /// <summary>
        /// The path to the My Documents folder.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.CommonDocs")]
        public const string CommonDocs = "{commondocs}";

        /// <summary>
        /// The path to the My Documents folder.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserDocs")]
        public const string UserDocs = "{userdocs}";

        /// <summary>
        /// The path to the current user's Favorites folder. (There is no common Favorites folder.)
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserFavorites")]
        public const string UserFavorites = "{userfavorites}";

        /// <summary>
        /// The path to the current user's Fonts folder. Only Windows 10 Version 1803 and later supports {userfonts}. Same directory as {localappdata}\Microsoft\Windows\Fonts.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserFonts")]
        public const string UserFonts = "{userfonts}";

        /// <summary>
        /// The path to the current user's Program Files directory. Only Windows 7 and later supports {userpf}; if used on previous Windows versions, it will translate to the same directory as {localappdata}\Programs.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserProgramFiles")]
        public const string UserProgramFiles = "{userpf}";

        /// <summary>
        /// The path to the Programs folder on the Start Menu.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.CommonPrograms")]
        public const string CommonPrograms = "{commonprograms}";

        /// <summary>
        /// The path to the Programs folder on the Start Menu.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserPrograms")]
        public const string UserPrograms = "{userprograms}";

        /// <summary>
        /// The path to the current user's Saved Games directory.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserSavedGames")]
        public const string UserSavedGames = "{usersavedgames}";

        /// <summary>
        /// The path to the current user's Send To folder. (There is no common Send To folder.)
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserSendTo")]
        public const string UserSendTo = "{usersendto}";

        /// <summary>
        /// The path to the top level of the Start Menu.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.CommonStartMenu")]
        public const string CommonStartMenu = "{commonstartmenu}";

        /// <summary>
        /// The path to the top level of the Start Menu.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserStartMenu")]
        public const string UserStartMenu = "{userstartmenu}";

        /// <summary>
        /// The path to the Startup folder on the Start Menu.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.CommonStartup")]
        public const string CommonStartup = "{commonstartup}";

        /// <summary>
        /// The path to the Startup folder on the Start Menu.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserStartup")]
        public const string UserStartup = "{userstartup}";

        /// <summary>
        /// The path to the Templates folder.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.CommonTemplates")]
        public const string CommonTemplates = "{commontemplates}";

        /// <summary>
        /// The path to the Templates folder.
        /// </summary>
        [Obsolete("Use InnoConstants.Shell.UserTemplates")]
        public const string UserTemplates = "{usertemplates}";
        
        public static class Directories
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
        }

        public static class Shell
        {
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

        public static class Inno
        {
            /// <summary>
            /// The full pathname of the system's standard command interpreter, Windows\System32\cmd.exe.
            /// Note that the COMSPEC environment variable is not used when expanding this constant.
            /// </summary>
            public const string Cmd = "{cmd}";

            /// <summary>
            /// The name of the computer the Setup or Uninstall program is running on
            /// (as returned by the Windows GetComputerName function).
            /// </summary>
            public const string ComputerName = "{computername}";

            /// <summary>
            /// The name of the folder the user selected on Setup's Select Start Menu Folder wizard page.
            /// This differs from {group} in that it is only the name; it does not include a path.
            /// </summary>
            public const string GroupName = "{groupname}";

            /// <summary>
            /// (Special-purpose) Translates to the window handle of the Setup program's background window.
            /// </summary>
            public const string Hwnd = "{hwnd}";

            /// <summary>
            /// (Special-purpose) Translates to the window handle of the Setup wizard window. This handle is set to '0'
            /// if the window handle isn't available at the time the translation is done.
            /// </summary>
            public const string WizardHwnd = "{wizardhwnd}";

            /// <summary>
            /// The internal name of the selected language. See the [Languages] section documentation for more information.
            /// </summary>
            public const string Language = "{language}";

            /// <summary>
            /// The full pathname of the Setup program file, e.g. "C:\SETUP.EXE".
            /// </summary>
            public const string SrcExe = "{srcexe}";

            /// <summary>
            /// The full pathname of the uninstall program extracted by Setup,
            /// e.g. "C:\Program Files\My Program\unins000.exe". This constant is typically used in an [Icons] section entry
            /// for creating an Uninstall icon. It is only valid if Uninstallable is yes (the default setting).
            /// </summary>
            public const string UninstallExe = "{uninstallexe}";

            /// <summary>
            /// The user name that Windows is registered to. This information is read from the registry.
            /// </summary>
            public const string SysUserInfoName = "{sysuserinfoname}";

            /// <summary>
            /// The user organization that Windows is registered to. This information is read from the registry.
            /// </summary>
            public const string SysUserInfoOrg = "{sysuserinfoorg}";

            /// <summary>
            /// The name that the user entered on the User Information wizard page (which can be enabled via the UserInfoPage directive). Typically, these constants are used in [Registry] or [INI] entries to save their values for later use.
            /// </summary>
            public const string UserInfoName = "{userinfoname}";

            /// <summary>
            /// The organization that the user entered on the User Information wizard page (which can be enabled via the UserInfoPage directive). Typically, these constants are used in [Registry] or [INI] entries to save their values for later use.
            /// </summary>
            public const string UserInfoOrg = "{userinfoorg}";

            /// <summary>
            /// The serial number that the user entered on the User Information wizard page (which can be enabled via the UserInfoPage directive). Typically, these constants are used in [Registry] or [INI] entries to save their values for later use.
            /// </summary>
            public const string UserInfoSerial = "{userinfoserial}";

            /// <summary>
            /// The name of the user who is running Setup or Uninstall program (as returned by the GetUserName function).
            /// </summary>
            public const string UserName = "{username}";

            /// <summary>
            /// The log file name, or an empty string if logging is not enabled.
            /// </summary>
            public const string Log = "{log}";

            /// <summary>
            /// Returns the constant representing the value of an environment variable.
            /// </summary>
            /// <param name="variableName">The name of the environment variable to use.</param>
            /// <param name="defaultValue">The string to embed if the specified variable does not exist
            /// on the user's system. </param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>
            /// {%COMSPEC}
            /// {%PROMPT|$P$G}
            /// </example>
            public static string GetEnvironmentVariable(string variableName, string defaultValue = null)
            {
                if (!string.IsNullOrWhiteSpace(defaultValue))
                    variableName += "|" + defaultValue;
                return $"{{%{variableName}}}";
            }

            /// <summary>
            /// Returns the constant of a value from an .INI file.
            /// </summary>
            /// <param name="filename">The name of the .INI file to read from.</param>
            /// <param name="section">The name of the section to read from.</param>
            /// <param name="key">The name of the key to read.</param>
            /// <param name="defaultValue">The string to embed if the specified key does not exist.</param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>{ini:{win}\MyProg.ini,Settings,Path|{autopf}\My Program}</example>
            public static string GetIniVariable(string filename, string section, string key, string defaultValue = null)
            {
                var val = $"{filename},{section},{key}";
                if (!string.IsNullOrWhiteSpace(defaultValue))
                    val += "|" + defaultValue;
                return $"{{ini:{val}}}";
            }

            /// <summary>
            /// Returns the constant of a custom message value based on the active language.
            /// </summary>
            /// <param name="messageName">The name of custom message to read from.
            /// See the [CustomMessages] section documentation for more information.</param>
            /// <param name="arguments">Optionally specifies a comma separated list of arguments to the message value.</param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>{cm:LaunchProgram,Inno Setup}</example>
            public static string GetCustomMessage(string messageName, params string[] arguments)
            {
                return arguments.Length == 0
                    ? $"{{cm:{messageName}}}"
                    : $"{{cm:{messageName},{string.Join(",", arguments)}}}";
            }

            /// <summary>
            /// Returns the constant of a registry value.
            /// </summary>
            /// <param name="key">The root key.</param>
            /// <param name="subkey">The name of the subkey to read from.</param>
            /// <param name="valueName">The name of the value to read.
            /// Leave <paramref name="valueName"/> blank if you wish to read the "default" value of a key.</param>
            /// <param name="defaultValue">The string to embed if the specified registry value does not exist,
            /// or is not a string type (REG_SZ or REG_EXPAND_SZ).</param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>{reg:HKA\Software\My Program,Path|{autopf}\My Program}</example>
            public static string GetRegValue(
                RegistryKeys key,
                string subkey,
                string valueName = null,
                string defaultValue = null)
            {
                valueName ??= string.Empty;
                var val = $"{key}\\{subkey}";
                if (!string.IsNullOrWhiteSpace(valueName))
                    val += "," + valueName;
                if (!string.IsNullOrWhiteSpace(defaultValue))
                    val += "|" + defaultValue;
                return $"{{reg:{val}}}";
            }

            /// <summary>
            /// Returns the constant of a command line parameter value.
            /// </summary>
            /// <param name="parameterName">The name of the command line parameter to read from.</param>
            /// <param name="defaultValue">
            /// The string to embed if the specified command line parameter does not exist,
            /// or its value could not be determined.</param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>{param:Path|{autopf}\My Program}</example>
            public static string GetCommandLineParameter(string parameterName, string defaultValue = null)
            {
                if (!string.IsNullOrWhiteSpace(defaultValue))
                    parameterName += "|" + defaultValue;
                return $"{{param:{parameterName}}}";
            }

            /// <summary>
            /// Returns the constant of the extracted drive letter and colon (e.g. "C:") from the specified path.
            /// In the case of a UNC path, it returns the server and share name (e.g. "\\SERVER\SHARE").
            /// </summary>
            /// <param name="path">The path.</param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>
            /// {drive:{src}}
            /// {drive:c:\path\file}
            /// {drive:\\server\share\path\file}
            /// </example>
            public static string GetDrive(string path)
            {
                return $"{{drive:{path}}}";
            }
        }
    }
}