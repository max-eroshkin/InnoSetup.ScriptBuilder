namespace InnoSetup.ScriptBuilder
{
    using System;

    /// <summary>
    /// Specifies the flags of an <c>[Icons]</c> entry.
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=iconssection">[Icons] section</a>.
    /// </summary>
    [Flags]
    public enum IconFlags
    {
        UninsNeverUninstall = 1,
        RunMinimized = 1 << 1,
        CreateOnlyIfFileExists = 1 << 2,
        UseAppPaths = 1 << 3,
        CloseOnExit = 1 << 4,
        DontCloseOnExit = 1 << 5,
        RunMaximized = 1 << 6,

        [Obsolete("Removed in Inno Setup 6.3")]
        FolderShortcut = 1 << 7,
        ExcludeFromShowInNewInstall = 1 << 8,
        PreventPinning = 1 << 9
    }
}
