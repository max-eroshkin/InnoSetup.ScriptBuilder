namespace InnoSetup.ScriptBuilder
{
    using System;

    public class DelegateScriptBuilder : ScriptBuilderBase
    {
        public DelegateScriptBuilder(Action<ScriptBuilderBase> config)
        {
            _ = config ?? throw new ArgumentNullException(nameof(config), "config cannot be null");
            config(this);
        }
    }
}