namespace InnoSetup.ScriptBuilder;

/// <summary>
/// Defines a key the compiler and Setup can use to verify files with the
/// <see cref="FileFlags.ISSigVerify"/> flag.
/// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
/// </summary>
public class ISSigKeyEntry : ModelBase
{
    /// <summary>
    /// The internal name of the key. Not stored in the resulting Setup file(s).
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A space separated list of internal group names, specifying how to group the key.
    /// Not stored in the resulting Setup file(s).
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public string Group { get; set; }

    /// <summary>
    /// The ID of the key. Used by the compiler to double check the values of
    /// <see cref="KeyFile"/>, <see cref="PublicX"/> and <see cref="PublicY"/>.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public string KeyID { get; set; }

    /// <summary>
    /// The private or public key file. Must be set if <see cref="PublicX"/> and <see cref="PublicY"/> aren't set.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public string KeyFile { get; set; }

    /// <summary>
    /// The "public-x" value of the key. Must be set if <see cref="KeyFile"/> isn't set.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public string PublicX { get; set; }

    /// <summary>
    /// The "public-y" value of the key. Must be set if <see cref="KeyFile"/> isn't set.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public string PublicY { get; set; }

    /// <summary>
    /// The runtime ID of the key, used by the <c>ISSigVerify</c> support function.
    /// Stored in the resulting Setup file(s).
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=issigkeyssection">[ISSigKeys]</a>.
    /// </summary>
    public string RuntimeID { get; set; }
}