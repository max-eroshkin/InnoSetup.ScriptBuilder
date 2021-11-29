namespace InnoSetup.ScriptBuilder.Model.SetupSection
{
    using System;

    [Flags]
    public enum Architectures
    {
        X86 = 1,
        X64 = 1 << 1,
        Arm64 = 1 << 2,
        Ia64 = 1 << 3,
    }
}