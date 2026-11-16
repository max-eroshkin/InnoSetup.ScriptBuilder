namespace InnoSetup.ScriptBuilder;

/// <summary>
/// Specifies the value of the <c>Encryption</c> directive.
/// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_encryption">Encryption</a>.
/// </summary>
public enum EncryptionMode
{
    /// <summary>
    /// Nothing is encrypted (the default).
    /// </summary>
    No,

    /// <summary>
    /// Files compiled into the installation are encrypted using XChaCha20.
    /// </summary>
    Yes,

    /// <summary>
    /// The entire installation is encrypted. The password must be specified using the <c>/PASSWORD=</c>
    /// command-line parameter.
    /// </summary>
    Full
}