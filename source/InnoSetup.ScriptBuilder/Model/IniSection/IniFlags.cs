namespace InnoSetup.ScriptBuilder
{
    using System;

    [Flags]
    public enum IniFlags
    {
        CreateKeyIfDoesntExist = 1,
        UninsDeleteEntry = 1 << 1,
        UninsDeleteSection = 1 << 2,
        UninsDeleteSectionIfEmpty = 1 << 3
    }
}