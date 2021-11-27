namespace InnoSetup.ScriptBuilder.Model.SetupSection
{
    using System;

    [Flags]
    public enum ArchitecturesInstallIn64BitMode
    {
        X64 = 1 << 1,
        Arm64 = 1 << 2,
        Ia64 = 1 << 3,
    }
}