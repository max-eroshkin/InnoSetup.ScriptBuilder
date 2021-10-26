using System;

namespace InnoSetup.ScriptBuilder
{
    [Flags]
    public enum SetupPrivilegesRequiredOverrides
    {
        CommandLine = 1,
        Dialog = 2
    }
}