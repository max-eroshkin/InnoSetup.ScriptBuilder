namespace InnoSetup.ScriptBuilder.Model.SetupSection
{
    using System;

    [Flags]
    public enum SetupPrivilegesRequiredOverrides
    {
        CommandLine = 1,
        Dialog = 2
    }
}