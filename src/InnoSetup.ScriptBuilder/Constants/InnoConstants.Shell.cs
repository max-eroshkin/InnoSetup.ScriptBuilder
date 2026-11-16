namespace InnoSetup.ScriptBuilder
{
    public static partial class InnoConstants
    {
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
    }
}