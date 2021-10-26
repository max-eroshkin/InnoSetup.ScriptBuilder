#nullable enable
using System;

namespace InnoSetup.ScriptBuilder
{
    public class IssBuilderException : Exception
    {
        public IssBuilderException()
        {
        }
        
        public IssBuilderException(string? message)
            :base(message)
        {
        }

        public IssBuilderException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}