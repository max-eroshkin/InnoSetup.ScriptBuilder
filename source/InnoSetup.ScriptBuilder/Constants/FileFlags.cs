namespace InnoSetup.ScriptBuilder
{
    using System;

    [Flags]
    public enum FileFlags : ulong
    {
        _32bit = 0x01,
        _64bit = 0x2,
        AllowUnsafeFiles = 0x4,
        CompareTimestamp = 0x8,
        ConfirmOverwrite = 0x10,
        CreateAllSubdirs = 0x20,
        DeleteAfterInstall = 0x40,
        DontCopy = 0x80,
        DontVerifyChecksum = 0x100,
        External = 0x200,
        FontIsntTrueType = 0x400,
        GacInstall = 0x800,
        IgnoreVersion = 0x1000,
        IsReadme = 0x2000,
        NoCompression = 0x4000,
        NoEncryption = 0x8000,
        NoRegError = 0x10000,
        OnlyIfDestFileExists = 0x20000,
        OnlyIfDoesntExist = 0x40000,
        OverwriteReadonly = 0x80000,
        PromptIfolder = 0x100000,
        RecurseSubdirs = 0x200000,
        RegServer = 0x400000,
        RegTypeLib = 0x800000,
        ReplaceSameVersion = 0x1000000,
        RestartReplace = 0x2000000,
        SetNtfsCompression = 0x4000000,
        SharedFile = 0x8000000,
        Sign = 0x10000000,
        SignOnce = 0x20000000,
        SkipIfSourceDoesntExist = 0x40000000,
        SolidBreak = 0x80000000,
        SortFilesByExtension = 0x100000000,
        SortFilesByName = 0x200000000,
        Touch = 0x400000000,
        UninsNoSharedFilePrompt = 0x800000000,
        UninsRemoveReadonly = 0x1000000000,
        UninsRestartDelete = 0x2000000000,
        UninsNeverUninstall = 0x4000000000,
        UnsetNtfsCompression = 0x8000000000
    }
}