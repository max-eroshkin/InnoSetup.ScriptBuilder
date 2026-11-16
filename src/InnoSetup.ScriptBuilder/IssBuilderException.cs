#nullable enable
namespace InnoSetup.ScriptBuilder
{
    using System;

    public class IssBuilderException : Exception
    {
        public IssBuilderException()
        {
        }

        public IssBuilderException(string? message)
            : base(message)
        {
        }

        public IssBuilderException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}