namespace InnoSetup.ScriptBuilder
{
    using System;

    /// <summary>
    /// Specifies the direction of the <c>BackColor</c> gradient, which was removed in Inno Setup 6.4.
    /// </summary>
    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public enum BackColorDirection
    {
        TopToBottom,
        LeftToRight
    }
}
