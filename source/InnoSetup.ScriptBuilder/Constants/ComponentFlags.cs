namespace InnoSetup.ScriptBuilder
{
    using System;

    [Flags]
    public enum ComponentFlags
    {
        Fixed = 0x1,
        Restart = 0x2,
        DisableNoUninstallWarning = 0x4,
        Exclusive = 0x8,
        DontInheritCheck = 0x10
    }
}