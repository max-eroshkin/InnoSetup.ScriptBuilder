namespace InnoSetup.ScriptBuilder
{
    using System;

    /// <summary>
    /// Marks an <see cref="Enum"/> member whose Inno Setup representation cannot be derived from the member name.
    /// </summary>
    /// <remarks>
    /// Typical values are <c>enhanced/nopassword</c> or <c>pbkdf2/220000</c>. <see cref="ValueExtensions.GetString(Enum)"/>
    /// writes <see cref="Value"/> verbatim instead of applying the default lower-casing/underscore removal.
    /// See <see href="https://jrsoftware.org/ishelp/index.php?topic=setupsection">[Setup] section</see>.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class IssValueAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssValueAttribute"/> class.
        /// </summary>
        /// <param name="value">The exact value written to the generated script.</param>
        public IssValueAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the exact value written to the generated script.
        /// </summary>
        public string Value { get; }
    }
}