namespace InnoSetup.ScriptBuilder
{
    /// <summary>
    /// Specifies whether the alpha channel of <c>WizardImageFile</c> is used.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardimagealphaformat">WizardImageAlphaFormat</a>.
    /// </summary>
    public enum WizardImageAlphaFormat
    {
        /// <summary>
        /// The alpha channel is not used.
        /// </summary>
        /// <remarks>
        /// Renamed from the never-valid <c>Ignored</c> member in Inno Setup 7.1.1 migration: the directive accepts
        /// <c>none</c>, not <c>ignored</c>.
        /// </remarks>
        None,

        /// <summary>
        /// The alpha channel is taken from the image itself.
        /// </summary>
        Defined,

        /// <summary>
        /// The alpha channel values of the image are premultiplied.
        /// </summary>
        Premultiplied
    }
}
