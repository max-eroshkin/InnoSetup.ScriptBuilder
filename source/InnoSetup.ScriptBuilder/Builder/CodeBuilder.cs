namespace InnoSetup.ScriptBuilder
{
    using System.IO;
    using System.Text;

    public class CodeBuilder : IBuilder
    {
        private readonly StringBuilder _data = new();

        public string SectionName => "Code";
        
        public CodeBuilder CreateEntry(string script)
        {
            _data.AppendLine(script);
            return this;
        }

        public void Write(TextWriter writer)
        {
            if (_data.Length == 0)
                return;
            writer.WriteLine($"\r\n[{SectionName}]");
            writer.Write(_data);
        }
    }
}