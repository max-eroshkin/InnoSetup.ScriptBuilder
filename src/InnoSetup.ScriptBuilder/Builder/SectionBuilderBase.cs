namespace InnoSetup.ScriptBuilder;

using System.Runtime.CompilerServices;

public abstract class SectionBuilderBase<TBuilder, TData>
    where TData : ModelBase
    where TBuilder : class
{
    public abstract string SectionName { get; }

    protected TData Data { get; set; }

    public TBuilder Parameter(string name, string value, bool needQuotes = true)
    {
        if (Data.Aux.ContainsKey(name))
            throw new IssBuilderException($"The section '{SectionName}' already contains parameter '{name}'");
        Data.Aux.Add(name, (value, needQuotes));
        return this as TBuilder;
    }

    public TBuilder Parameter(string name, object value)
    {
        if (Data.Aux.ContainsKey(name))
            throw new IssBuilderException($"The section '{SectionName}' already contains parameter '{name}'");
        Data.Aux.Add(name, (value, false));
        return this as TBuilder;
    }

    protected TBuilder SetPropertyValue(object value, [CallerMemberName] string name = null)
    {
        return SetPropertyValue(Data, name, value);
    }

    private TBuilder SetPropertyValue(object instance, string method, object value)
    {
        var propertyName = method;
        var type = instance.GetType();
        var property = type.GetProperty(propertyName) ??
                       throw new IssBuilderException(
                           $"Property '{propertyName}' in class {type.Name} not found");
        property.SetValue(instance, value);
        return this as TBuilder;
    }
}