namespace InnoSetup.ScriptBuilder.Model.RegistrySection
{
    using System;

    [Flags]
    public enum RegistryFlags
    {
        _32Bit = 0x1,
        _64Bit = 0x2,
        CreateValueIfDoesntExist = 0x4,
        UninsDeleteValue = 0x8,
        UninsClearValue = 0x10,
        UninsDeleteEntireKey = 0x20,
        UninsDeleteEntireKeyIfEmpty = 0x40,
        PreserveStringType = 0x80,
        DeleteKey = 0x100,
        DeleteValue = 0x200,
        NoError = 0x400,
        DontCreateKey = 0x800,
    }
}