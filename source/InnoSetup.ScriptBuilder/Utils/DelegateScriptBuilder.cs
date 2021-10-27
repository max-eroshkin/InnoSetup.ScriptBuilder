namespace InnoSetup.ScriptBuilder
{
    using System;

    public class DelegateScriptBuilder : IssBuilder
    {
        public DelegateScriptBuilder(Action<IssBuilder> config)
        {
            _ = config ?? throw new ArgumentNullException(nameof(config), "config cannot be null");
            config(this);
        }
    }
}