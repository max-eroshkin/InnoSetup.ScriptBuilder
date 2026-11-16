namespace InnoSetup.ScriptBuilder
{
    using System;

    [Flags]
    public enum DirFlags
    {
        UninsNeverUninstall = 0x01, 
        DeleteAfterInstall = 0x02,
        UninsAlwaysUninstall = 0x04, 
        SetNtfsCompression = 0x08, 
        UnsetNtfsCompression = 0x10
    }
}