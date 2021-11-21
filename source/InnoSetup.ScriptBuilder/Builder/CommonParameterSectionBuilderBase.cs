namespace InnoSetup.ScriptBuilder
{
    using Model;
    using Model.FileSection;

    /// <summary>
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=commonparams">ISS documentation.</a>
    /// </summary>
    public abstract class CommonParameterSectionBuilderBase<TBuilder, TData> : ParameterSectionBuilderBase<TBuilder, TData>
        where TBuilder : class 
        where TData : CommonParameterSectionEntryBase, new()
    {
        public TBuilder Languages(string value) => SetPropertyValue(value);
        public TBuilder MinVersion(string value) => SetPropertyValue(value);
        public TBuilder OnlyBelowVersion(string value) => SetPropertyValue(value);
    }
}