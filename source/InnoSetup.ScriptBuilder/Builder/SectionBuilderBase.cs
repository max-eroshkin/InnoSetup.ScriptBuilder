﻿namespace InnoSetup.ScriptBuilder
{
    using System;
    using System.Runtime.CompilerServices;

    public abstract class SectionBuilderBase<TBuilder, TData>
        where TData : class
        where TBuilder : class
    {
        protected TData Data { get; set; }

        protected TBuilder SetPropertyValue(object value, [CallerMemberName] string name = null)
        {
            return SetPropertyValue(Data, name, value);
        }

        private TBuilder SetPropertyValue(object instance, string method, object value)
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