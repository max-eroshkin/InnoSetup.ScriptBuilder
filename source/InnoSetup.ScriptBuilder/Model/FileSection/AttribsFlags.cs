using System;

namespace InnoSetup.ScriptBuilder
{
    [Flags]
    public enum AttribsFlags
    {
        Readonly = 1,
        Hidden = 2,
        System = 4,
        NotContentIndexed = 8
    }
}