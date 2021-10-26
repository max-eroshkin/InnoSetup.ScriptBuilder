using System;
using InnoSetup.ScriptBuilder.Builder;

namespace InnoSetup.ScriptBuilder
{
    public class DelegateScriptBuilder : ScriptBuilderBase
    {
        public DelegateScriptBuilder(Action<ScriptBuilderBase> config)
        {
            _ = config ?? throw new ArgumentNullException(nameof(config), "config cannot be null");
            config(this);
        }
        
    }
}