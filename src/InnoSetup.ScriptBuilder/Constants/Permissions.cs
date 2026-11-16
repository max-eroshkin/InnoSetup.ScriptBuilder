namespace InnoSetup.ScriptBuilder
{
    using System;

    [Flags]
    public enum Permissions
    {
        ReadExec = 1,
        Modify = 2,
        Full = 4
    }
}