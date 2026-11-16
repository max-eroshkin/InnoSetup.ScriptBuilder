namespace InnoSetup.ScriptBuilder;

/// <summary>
/// Creates entries of the <c>[ISSigKeys]</c> section.
/// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
/// </summary>
public interface IIssigKeyEntryBuilder
{
    /// <summary>
    /// Creates an entry for a key referenced by its key file.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    /// <param name="name">The internal name of the key.</param>
    /// <param name="keyFile">The private or public key file.</param>
    /// <returns>The builder of the created entry.</returns>
    ISSigKeysBuilder CreateEntry(string name, string keyFile);

    /// <summary>
    /// Creates an entry for a key referenced by its public values.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    /// <param name="name">The internal name of the key.</param>
    /// <param name="publicX">The "public-x" value of the key.</param>
    /// <param name="publicY">The "public-y" value of the key.</param>
    /// <returns>The builder of the created entry.</returns>
    ISSigKeysBuilder CreateEntryFromPublicKey(string name, string publicX, string publicY);
}