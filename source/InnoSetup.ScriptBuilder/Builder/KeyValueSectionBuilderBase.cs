namespace InnoSetup.ScriptBuilder
{
    using System;
    using System.IO;
    using System.Reflection;
    using Model.FileSection;

    public abstract class KeyValueSectionBuilderBase<TBuilder, TData> : SectionBuilderBase<TBuilder, TData>, IBuilder
        where TData : ModelBase, new()
        where TBuilder : class
    {
        public void Write(TextWriter writer)
        {
            if (Data is null)
                return;

            writer.WriteLine($"[{SectionName}]");
            WriteProperties(writer);
            WriteAux(writer);
        }

        protected TBuilder CreateEntryInternal()
        {
            if (Data is not null)
                throw new InvalidOperationException($"Section {SectionName} already created");

            Data = new TData();
            return this as TBuilder;
        }

        private void WriteProperties(TextWriter writer)
        {
            var type = Data.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo info in properties)
            {
                var value = info.GetValue(Data);
                if (value is null)
                    continue;

                var str = value.GetString();
                if (str is not null)
                    writer.WriteLine($"{info.Name}={str}");
            }
        }

        private void WriteAux(TextWriter writer)
        {
            foreach (var parameter in Data.Aux)
            {
                if (parameter.Value.value is null)
                    continue;

                var str = parameter.Value.value.GetString(parameter.Value.needQuotes);
                if (str is not null)
                    writer.WriteLine($"{parameter.Key}={str}");
            }
        }
    }
}