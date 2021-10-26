using System;
using System.Runtime.CompilerServices;

namespace InnoSetup.ScriptBuilder.Builder
{
    public abstract class BuilderBase<TBuilder, TData>
        where TData : class, new() 
        where TBuilder : class
    {
        protected TData _data;
        protected TData Data => _data ??= new TData();

        protected TBuilder SetPropertyValue(object value, [CallerMemberName ] string name = null)
        {
            return SetPropertyValue(Data, name, value);
        }

        protected TBuilder SetPropertyValue(object instance, string method, object value)
        {
            var propertyName = method;
            var type = instance.GetType();
            var property = type.GetProperty(propertyName) ??
                           throw new NullReferenceException(
                               $"Property '{propertyName}' in class {type.Name} not found");
            property.SetValue(instance, value);
            return this as TBuilder;
        }
    }
}