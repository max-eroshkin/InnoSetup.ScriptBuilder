namespace InnoSetup.ScriptBuilder
{
    public static partial class InnoConstants
    {
        /// <summary>
        /// Contains <a href="https://jrsoftware.org/inno-setup/documentation/?topic=consts">Inno Setup "auto" constants.</a>
        /// </summary>
        /// <remarks>
        /// Every auto constant automatically maps to its "common" form, unless the installation is running in
        /// non-administrative install mode, in which case it maps to its "user" form.
        /// The Inno Setup documentation recommends always using these "auto" constants when possible
        /// to avoid mistakes.
        /// </remarks>
        public static class Auto
        {
            /// <summary>
            /// The path to the Application Data folder: {commonappdata} (administrative) or {userappdata} (non administrative).
            /// </summary>
            public const string AppData = "{autoappdata}";

            /// <summary>
            /// Common Files: {commoncf} (administrative) or {usercf} (non administrative).
            /// </summary>
            public const string CommonFiles = "{autocf}";

            /// <summary>
            /// 32-bit Common Files: {commoncf32} (administrative) or {usercf} (non administrative).
            /// </summary>
            public const string CommonFiles32 = "{autocf32}";

            /// <summary>
            /// 64-bit Common Files: {commoncf64} (administrative) or {usercf} (non administrative).
            /// </summary>
            public const string CommonFiles64 = "{autocf64}";

            /// <summary>
            /// The path to the desktop folder: {commondesktop} (administrative) or {userdesktop} (non administrative).
            /// </summary>
            public const string Desktop = "{autodesktop}";

            /// <summary>
            /// The path to the My Documents folder: {commondocs} (administrative) or {userdocs} (non administrative).
            /// </summary>
            public const string Docs = "{autodocs}";

            /// <summary>
            /// The path to the Fonts folder: {commonfonts} (administrative) or {userfonts} (non administrative).
            /// </summary>
            public const string Fonts = "{autofonts}";

            /// <summary>
            /// Program Files: {commonpf} (administrative) or {userpf} (non administrative).
            /// </summary>
            public const string ProgramFiles = "{autopf}";

            /// <summary>
            /// 32-bit Program Files: {commonpf32} (administrative) or {userpf} (non administrative).
            /// </summary>
            public const string ProgramFiles32 = "{autopf32}";

            /// <summary>
            /// 64-bit Program Files: {commonpf64} (administrative) or {userpf} (non administrative).
            /// </summary>
            public const string ProgramFiles64 = "{autopf64}";

            /// <summary>
            /// The path to the Programs folder on the Start menu: {commonprograms} (administrative) or {userprograms} (non administrative).
            /// </summary>
            public const string Programs = "{autoprograms}";

            /// <summary>
            /// The path to the top level of the Start menu: {commonstartmenu} (administrative) or {userstartmenu} (non administrative).
            /// </summary>
            public const string StartMenu = "{autostartmenu}";

            /// <summary>
            /// The path to the Startup folder on the Start menu: {commonstartup} (administrative) or {userstartup} (non administrative).
            /// </summary>
            public const string Startup = "{autostartup}";

            /// <summary>
            /// The path to the Templates folder: {commontemplates} (administrative) or {usertemplates} (non administrative).
            /// </summary>
            public const string Templates = "{autotemplates}";
        }
    }
}
