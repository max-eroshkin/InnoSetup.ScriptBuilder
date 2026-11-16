namespace InnoSetup.ScriptBuilder;

using System;

[Flags]
public enum FileFlags : ulong
{
    _32bit = 1ul,
    _64bit = 1ul << 1,
    AllowUnsafeFiles = 1ul << 2,
    CompareTimestamp = 1ul << 3,
    ConfirmOverwrite = 1ul << 4,
    CreateAllSubdirs = 1ul << 5,
    DeleteAfterInstall = 1ul << 6,
    DontCopy = 1ul << 7,
    DontVerifyChecksum = 1ul << 8,
    External = 1ul << 9,
    FontIsntTrueType = 1ul << 10,
    GacInstall = 1ul << 11,
    IgnoreVersion = 1ul << 12,
    IsReadme = 1ul << 13,
    NoCompression = 1ul << 14,
    NoEncryption = 1ul << 15,
    NoRegError = 1ul << 16,
    OnlyIfDestFileExists = 1ul << 17,
    OnlyIfDoesntExist = 1ul << 18,
    OverwriteReadonly = 1ul << 19,
    PromptIfolder = 1ul << 20,
    RecurseSubdirs = 1ul << 21,
    RegServer = 1ul << 22,
    RegTypeLib = 1ul << 23,
    ReplaceSameVersion = 1ul << 24,
    RestartReplace = 1ul << 25,
    SetNtfsCompression = 1ul << 26,
    SharedFile = 1ul << 27,
    Sign = 1ul << 28,
    SignCheck = 1ul << 29,
    SignOnce = 1ul << 30,
    SkipIfSourceDoesntExist = 1ul << 31,
    SolidBreak = 1ul << 32,
    SortFilesByExtension = 1ul << 33,
    SortFilesByName = 1ul << 34,
    Touch = 1ul << 35,
    UninsNoSharedFilePrompt = 1ul << 36,
    UninsRemoveReadonly = 1ul << 37,
    UninsRestartDelete = 1ul << 38,
    UninsNeverUninstall = 1ul << 39,
    UnsetNtfsCompression = 1ul << 40,

    /// <summary>
    /// Instructs Setup not to copy an existing file, but instead to download it.
    /// Must be combined with the <see cref="External"/>, <see cref="IgnoreVersion"/> flags and the
    /// <see cref="FileEntry.DestName"/>, <see cref="FileEntry.ExternalSize"/> parameters.
    /// Cannot be combined with <see cref="CompareTimestamp"/> and <see cref="SkipIfSourceDoesntExist"/>.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    Download = 1ul << 41,

    /// <summary>
    /// Instructs Setup not to copy an existing archive file, but instead to extract it to the directory
    /// specified by <see cref="FileEntry.DestDir"/>.
    /// Must be combined with the <see cref="External"/> and <see cref="IgnoreVersion"/> flags.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    ExtractArchive = 1ul << 42,

    /// <summary>
    /// Instructs the compiler or Setup to verify the source file's signature using a key from the
    /// <c>[ISSigKeys]</c> section, allowing all keys by default.
    /// Cannot be combined with <see cref="Sign"/> and <see cref="SignOnce"/>; use <see cref="SignCheck"/> instead.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    ISSigVerify = 1ul << 43,

    /// <summary>
    /// Prevents the file from being stored with a timestamp, which helps to make builds reproducible.
    /// Cannot be combined with <see cref="CompareTimestamp"/> and <see cref="Touch"/>.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=filessection">[Files] section</a>.
    /// </summary>
    NoTimestamp = 1ul << 44,
}