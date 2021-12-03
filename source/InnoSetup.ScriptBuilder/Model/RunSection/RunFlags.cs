namespace InnoSetup.ScriptBuilder
{
    using System;

    [Flags]
    public enum RunFlags
    {
        _32bit = 1,
        _64bit = 1 << 1,
        NoWait = 1 << 2,
        WaitUntilIdle = 1 << 3,
        ShellExec = 1 << 4,
        SkipIfDoesntExist = 1 << 5,
        RunMinimized = 1 << 6,
        RunMaximized = 1 << 7,
        PostInstall = 1 << 8,
        Unchecked = 1 << 9,
        SkipIfSilent = 1 << 10,
        SkipIfNotSilent = 1 << 11,
        HideWizard = 1 << 12,
        RunHidden = 1 << 13,
        WaitUntilTerminated = 1 << 14,
        RunAsOriginalUser = 1 << 15,
        RunAsCurrentUser = 1 << 16,
        DontLogParameters = 1 << 17
    }
}