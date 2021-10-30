namespace InnoSetup.ScriptBuilder.Model
{
    using System.Collections.Generic;

    public abstract class ModelBase
    {
        public Dictionary<string, (object value, bool needQuotes)> Aux { get; } = new ();
    }
}