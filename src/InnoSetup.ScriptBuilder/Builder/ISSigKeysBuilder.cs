namespace InnoSetup.ScriptBuilder;

/// <summary>
/// Builds the <c>[ISSigKeys]</c> section.
/// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
/// </summary>
public class ISSigKeysBuilder : ParameterSectionBuilderBase<ISSigKeysBuilder, ISSigKeyEntry>, IIssigKeyEntryBuilder
{
    public override string SectionName => "ISSigKeys";

    /// <inheritdoc />
    public ISSigKeysBuilder CreateEntry(string name, string keyFile)
    {
        CreateEntryInternal();
        Name(name);
        KeyFile(keyFile);

        return this;
    }

    /// <inheritdoc />
    public ISSigKeysBuilder CreateEntryFromPublicKey(string name, string publicX, string publicY)
    {
        CreateEntryInternal();
        Name(name);
        PublicX(publicX);
        PublicY(publicY);

        return this;
    }

    /// <summary>
    /// A space separated list of internal group names, specifying how to group the key.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public ISSigKeysBuilder Group(string value) => SetPropertyValue(value);

    /// <summary>
    /// The ID of the key, used by the compiler to double check the <see cref="KeyFile"/>,
    /// <see cref="PublicX"/> and <see cref="PublicY"/> values.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public ISSigKeysBuilder KeyID(string value) => SetPropertyValue(value);

    /// <summary>
    /// The private or public key file. Must be set if <see cref="PublicX"/> and <see cref="PublicY"/> aren't set.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public ISSigKeysBuilder KeyFile(string value) => SetPropertyValue(value);

    /// <summary>
    /// The "public-x" value of the key. Must be set if <see cref="KeyFile"/> isn't set.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public ISSigKeysBuilder PublicX(string value) => SetPropertyValue(value);

    /// <summary>
    /// The "public-y" value of the key. Must be set if <see cref="KeyFile"/> isn't set.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public ISSigKeysBuilder PublicY(string value) => SetPropertyValue(value);

    /// <summary>
    /// The runtime ID of the key, used by the <c>ISSigVerify</c> support function.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public ISSigKeysBuilder RuntimeID(string value) => SetPropertyValue(value);

    private ISSigKeysBuilder Name(string value) => SetPropertyValue(value);
}