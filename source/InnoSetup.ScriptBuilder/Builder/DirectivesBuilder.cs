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

        /// <summary>
        /// Generates an include preprocessor directive.
        /// </summary>
        /// <param name="filePath">A filename if enclosed in angular brackets (&lt;filename.iss&gt;) or
        /// a filepath if not (c:\dir\filepath.iss).</param>
        public DirectivesBuilder Include(string filePath)
        {
            if (Regex.IsMatch(filePath, @"^\<.+\>$"))
                _builder.AppendFormat("#include {0}", filePath);
            else
                _builder.AppendFormat("#include \"{0}\"", filePath);

            _builder.AppendLine();

            return this;
        }

        /// <summary>
        /// Generates a variable/macro definition using an expression.
        /// </summary>
        /// <param name="variable">The variable or the macro identifier.</param>
        /// <param name="experession">The expression.</param>
        public DirectivesBuilder Define(string variable, string experession)
        {
            _builder.AppendFormat("#define {0} {1}", variable, experession);
            _builder.AppendLine();
            return this;
        }

        /// <summary>
        /// Generates a variable/macro definition using a value.
        /// </summary>
        /// <param name="variable">The variable or the macro identifier.</param>
        /// <param name="value">The value.</param>
        public DirectivesBuilder DefineVariable(string variable, object value)
        {
            _builder.AppendFormat("#define {0} {1}", variable, value.GetString());
            _builder.AppendLine();
            return this;
        }

        /// <summary>
        /// Generates #undef directive.
        /// </summary>
        /// <param name="variable">The variable or the macro identifier.</param>
        public DirectivesBuilder Undef(string variable)
        {
            _builder.AppendFormat("#undef {0}", variable);
            _builder.AppendLine();
            return this;
        }

        /// <summary>
        /// Inserts any text into the script.
        /// </summary>
        /// <param name="text">The text.</param>
        public DirectivesBuilder FreeText(string text)
        {
            _builder.Append(text);
            _builder.AppendLine();
            return this;
        }
    }
}