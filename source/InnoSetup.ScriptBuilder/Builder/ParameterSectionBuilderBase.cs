namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using Model.FileSection;

    public abstract class ParameterSectionBuilderBase<TBuilder, TData> : SectionBuilderBase<TBuilder, TData>, IBuilder
        where TData : ParameterSectionEntryBase, new()
        where TBuilder : class
    {
        private List<TData> _entryList;

        public TBuilder Languages(string value) => SetPropertyValue(value);
        public TBuilder MinVersion(string value) => SetPropertyValue(value);
        public TBuilder OnlyBelowVersion(string value) => SetPropertyValue(value);
        
        public void Write(TextWriter writer)
        {
            if (_entryList?.Count > 0)
            {
                writer.WriteLine($"[{SectionName}]");
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
                if (parameter.Value.value is null)
                    continue;
                
                var str = parameter.Value.value.GetString(parameter.Value.needQuotes);
                if (str is not null)
                    writer.Write($"{parameter.Key}: {str}; ");
            }
        }
    }
}