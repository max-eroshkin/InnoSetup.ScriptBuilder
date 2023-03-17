namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public abstract class ParameterSectionBuilderBase<TBuilder, TData> : SectionBuilderBase<TBuilder, TData>, IBuilder
        where TBuilder : class
        where TData : ModelBase, new()
    {
        private List<TData> _entryList;

        public void Write(TextWriter writer)
        {
            if (_entryList?.Count > 0)
            {
                writer.WriteLine($"\n[{SectionName}]");
                foreach (var entry in _entryList)
                    WriteEntry(writer, entry);
            }
        }

        protected TBuilder CreateEntryInternal()
        {
            _entryList ??= new List<TData>();
            _entryList.Add(Data = new TData());

            return this as TBuilder;
        }

        protected void WriteEntry(TextWriter writer, TData entry)
        {
            WriteProperties(writer, entry);
            WriteAux(writer, entry);
            writer.WriteLine();
        }

        private void WriteProperties(TextWriter writer, TData entry)
        {
            var type = entry.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo info in properties)
            {
                var value = info.GetValue(entry);
                if (value is null)
                    continue;

                var str = value.GetString();
                if (str is not null)
                    writer.Write($"{info.Name}: {str}; ");
            }
        }

        private void WriteAux(TextWriter writer, TData entry)
        {
            foreach (var parameter in entry.Aux)
            {
                if (parameter.Value.Value is null)
                    continue;

                var str = parameter.Value.Value.GetString(parameter.Value.NeedQuotes);
                if (str is not null)
                    writer.Write($"{parameter.Key}: {str}; ");
            }
        }
    }
}