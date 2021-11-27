namespace InnoSetup.ScriptBuilder.Model.SetupSection
{
    using System;
    using System.ComponentModel;

    [Flags]
    public enum SetupPrivilegesRequiredOverrides
    {
        CommandLine = 1,
        Dialog = 2
    }
}