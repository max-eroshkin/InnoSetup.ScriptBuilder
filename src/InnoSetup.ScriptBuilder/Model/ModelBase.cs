namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;

    public abstract class ModelBase
    {
        public Dictionary<string, (object Value, bool NeedQuotes)> Aux { get; } = new();
    }
}