namespace InnoSetup.ScriptBuilder
{
    using System;

    /// <summary>
    /// Represents a value of a <c>[Setup]</c> directive documented as
    /// <c>yes or no, or a scripted boolean expression</c>. See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setupsection">[Setup] section</a>.
    /// </summary>
    /// <remarks>
    /// A <see cref="YesNo"/> value is written as <c>yes</c>/<c>no</c>/<c>auto</c>, while a string is written
    /// verbatim and unquoted, so a scripted boolean expression such as <c>{code:IsSomething}</c> stays valid.
    /// </remarks>
    public readonly struct IssYesNo : IEquatable<IssYesNo>
    {
        private IssYesNo(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value written to the generated script.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Converts a <see cref="YesNo"/> value to <c>yes</c>, <c>no</c> or <c>auto</c>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator IssYesNo(YesNo value)
        {
            return new IssYesNo(value.GetString());
        }

        /// <summary>
        /// Uses a ready-made value as-is, without quoting it, which keeps scripted boolean expressions
        /// such as <c>{code:IsSomething}</c> working.
        /// </summary>
        /// <param name="value">The value written to the generated script verbatim.</param>
        public static implicit operator IssYesNo(string value)
        {
            return new IssYesNo(value);
        }

        /// <summary>
        /// Compares two values by their script value.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns><c>true</c> when both values are the same.</returns>
        public static bool operator ==(IssYesNo left, IssYesNo right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two values by their script value.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns><c>true</c> when the values are different.</returns>
        public static bool operator !=(IssYesNo left, IssYesNo right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc />
        public bool Equals(IssYesNo other)
        {
            return string.Equals(Value, other.Value, StringComparison.Ordinal);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is IssYesNo other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value != null ? StringComparer.Ordinal.GetHashCode(Value) : 0;
        }

        /// <summary>
        /// Returns the value written to the generated script.
        /// </summary>
        /// <returns>The script value.</returns>
        public override string ToString()
        {
            return Value;
        }
    }
}