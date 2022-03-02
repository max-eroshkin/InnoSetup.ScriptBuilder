namespace InnoSetup.ScriptBuilder
{
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class DirectivesBuilder
    {
        private readonly StringBuilder _builder = new();

        public string SectionName => "Directives";

        public void Write(TextWriter writer)
        {
            if (_builder.Length > 0)
                writer.Write(_builder);
        }
        
        public DirectivesBuilder Include(string filePath)
        {
            if (Regex.IsMatch(filePath, @"^\<.+\>$"))
                _builder.AppendFormat("#include {0}", filePath);
            else
                _builder.AppendFormat("#include \"{0}\"", filePath);

            _builder.AppendLine();

            return this;
        }

        public DirectivesBuilder Define(string variable, string experession)
        {
            _builder.AppendFormat("#define {0} {1}", variable, experession);
            _builder.AppendLine();
            return this;
        }

        public DirectivesBuilder Undef(string variable)
        {
            _builder.AppendFormat("#undef {0}", variable);
            _builder.AppendLine();
            return this;
        }

        public DirectivesBuilder FreeText(string text)
        {
            _builder.Append(text);
            _builder.AppendLine();
            return this;
        }
    }
}