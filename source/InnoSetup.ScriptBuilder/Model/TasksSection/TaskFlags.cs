namespace InnoSetup.ScriptBuilder.Model.TasksSection
{
    using System;

    [Flags]
    public enum TaskFlags
    {
        Exclusive = 1,
        Unchecked = 1 << 1,
        Restart = 1 << 2,
        CheckableAlone = 1 << 3,
        CheckedOnce = 1 << 4,
        DontInheritCheck = 1 << 5
    }
}