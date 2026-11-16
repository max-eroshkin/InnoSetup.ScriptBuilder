namespace InnoSetup.ScriptBuilder
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Represents a color value accepted by the Inno Setup <c>[Setup]</c> directives, for example
    /// <c>WizardImageBackColor</c>. See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/topic_setup_wizardimagebackcolor.htm">Colors</a>.
    /// </summary>
    /// <remarks>
    /// Three notations are supported and written as-is:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// a Delphi <c>TColor</c> integer, printed as <c>$bbggrr</c> (see the implicit <see cref="long"/> operator);
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// an RGB hexadecimal literal, for example <c>#fff</c> or <c>#rrggbb</c> (see <see cref="Hex"/>);
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// a color name, for example <c>cornflowerblue</c>, or the special values <c>none</c> and <c>window</c>
    /// (see <see cref="Named"/>).
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    public readonly struct IssColor : IEquatable<IssColor>
    {
        /// <summary>
        /// The <c>none</c> value, which leaves the color undefined.
        /// </summary>
        public static readonly IssColor None = Named("none");

        /// <summary>
        /// The <c>window</c> value, which uses the current Windows theme window color.
        /// </summary>
        public static readonly IssColor Window = Named("window");

        /// <summary>
        /// The <c>black</c> color.
        /// </summary>
        public static readonly IssColor Black = Named("black");

        /// <summary>
        /// The <c>maroon</c> color.
        /// </summary>
        public static readonly IssColor Maroon = Named("maroon");

        /// <summary>
        /// The <c>green</c> color.
        /// </summary>
        public static readonly IssColor Green = Named("green");

        /// <summary>
        /// The <c>olive</c> color.
        /// </summary>
        public static readonly IssColor Olive = Named("olive");

        /// <summary>
        /// The <c>navy</c> color.
        /// </summary>
        public static readonly IssColor Navy = Named("navy");

        /// <summary>
        /// The <c>purple</c> color.
        /// </summary>
        public static readonly IssColor Purple = Named("purple");

        /// <summary>
        /// The <c>teal</c> color.
        /// </summary>
        public static readonly IssColor Teal = Named("teal");

        /// <summary>
        /// The <c>gray</c> color.
        /// </summary>
        public static readonly IssColor Gray = Named("gray");

        /// <summary>
        /// The <c>silver</c> color.
        /// </summary>
        public static readonly IssColor Silver = Named("silver");

        /// <summary>
        /// The <c>red</c> color.
        /// </summary>
        public static readonly IssColor Red = Named("red");

        /// <summary>
        /// The <c>lime</c> color.
        /// </summary>
        public static readonly IssColor Lime = Named("lime");

        /// <summary>
        /// The <c>yellow</c> color.
        /// </summary>
        public static readonly IssColor Yellow = Named("yellow");

        /// <summary>
        /// The <c>blue</c> color.
        /// </summary>
        public static readonly IssColor Blue = Named("blue");

        /// <summary>
        /// The <c>fuchsia</c> color.
        /// </summary>
        public static readonly IssColor Fuchsia = Named("fuchsia");

        /// <summary>
        /// The <c>aqua</c> color.
        /// </summary>
        public static readonly IssColor Aqua = Named("aqua");

        /// <summary>
        /// The <c>white</c> color.
        /// </summary>
        public static readonly IssColor White = Named("white");

        private IssColor(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value written to the generated script.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a color from an RGB hexadecimal literal.
        /// </summary>
        /// <param name="r">The red component, 0–255.</param>
        /// <param name="g">The green component, 0–255.</param>
        /// <param name="b">The blue component, 0–255.</param>
        /// <returns>The <c>#rrggbb</c> notation.</returns>
        /// <exception cref="ArgumentOutOfRangeException">A component is outside the 0–255 range.</exception>
        public static IssColor Hex(int r, int g, int b)
        {
            CheckComponent(r, nameof(r));
            CheckComponent(g, nameof(g));
            CheckComponent(b, nameof(b));

            return new IssColor(
                $"#{r.ToString("x2", CultureInfo.InvariantCulture)}" +
                $"{g.ToString("x2", CultureInfo.InvariantCulture)}" +
                $"{b.ToString("x2", CultureInfo.InvariantCulture)}");
        }

        /// <summary>
        /// Creates a color from a color name without validating it, so that names added by future
        /// Inno Setup versions keep working.
        /// </summary>
        /// <param name="name">The color name, for example <c>cornflowerblue</c>.</param>
        /// <returns>The given name, written to the generated script verbatim.</returns>
        public static IssColor Named(string name)
        {
            return new IssColor(name);
        }

        /// <summary>
        /// Converts a Delphi <c>TColor</c> integer to the <c>$bbggrr</c> notation.
        /// </summary>
        /// <param name="value">The <c>TColor</c> value; only the low 24 bits are used.</param>
        public static implicit operator IssColor(long value)
        {
            return new IssColor($"${(value & 0xFFFFFF).ToString("x6", CultureInfo.InvariantCulture)}");
        }

        /// <summary>
        /// Converts a Delphi <c>TColor</c> integer to the <c>$bbggrr</c> notation.
        /// </summary>
        /// <param name="value">The <c>TColor</c> value; only the low 24 bits are used.</param>
        public static implicit operator IssColor(int value)
        {
            return new IssColor($"${(value & 0xFFFFFF).ToString("x6", CultureInfo.InvariantCulture)}");
        }

        /// <summary>
        /// Uses a ready-made color literal as-is, for example <c>#fff</c>, <c>#rrggbb</c>,
        /// <c>cornflowerblue</c>, <c>none</c> or <c>window</c>.
        /// </summary>
        /// <param name="value">The color literal written to the generated script verbatim.</param>
        public static implicit operator IssColor(string value)
        {
            return new IssColor(value);
        }

        /// <summary>
        /// Compares two colors by their script value.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns><c>true</c> when both colors have the same value.</returns>
        public static bool operator ==(IssColor left, IssColor right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two colors by their script value.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns><c>true</c> when the colors have different values.</returns>
        public static bool operator !=(IssColor left, IssColor right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc />
        public bool Equals(IssColor other)
        {
            return string.Equals(Value, other.Value, StringComparison.Ordinal);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is IssColor other && Equals(other);
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

        private static void CheckComponent(int value, string name)
        {
            if (value < 0 || value > 255)
                throw new ArgumentOutOfRangeException(name, value, "Color component must be in the 0-255 range.");
        }
    }
}
