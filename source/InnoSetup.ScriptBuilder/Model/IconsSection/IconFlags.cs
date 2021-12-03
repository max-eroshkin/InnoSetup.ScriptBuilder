namespace InnoSetup.ScriptBuilder
{
    using System;

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
        FolderShortcut = 1 << 7,
        ExcludeFromShowInNewInstall = 1 << 8,
        PreventPinning = 1 << 9
    }

    /*
     * = 1
     * = 1 << 1
     * = 1 << 2
     * = 1 << 3
     * = 1 << 4
     * = 1 << 5
     * = 1 << 6
     * = 1 << 7
     * = 1 << 8
     * = 1 << 9
     * = 1 << 10
     * = 1 << 11
     * = 1 << 12
     * = 1 << 13
     * = 1 << 14
 */
}