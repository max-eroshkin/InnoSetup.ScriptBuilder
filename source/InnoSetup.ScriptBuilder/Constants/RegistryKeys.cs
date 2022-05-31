// ReSharper disable InconsistentNaming
namespace InnoSetup.ScriptBuilder
{
    /// <summary>
    /// Contains registry root keys.
    /// </summary>
    public enum RegistryKeys
    {
        /// <summary>
        /// HKEY_CURRENT_USER
        /// </summary>
        HKCU,

        /// <summary>
        /// HKEY_LOCAL_MACHINE
        /// </summary>
        HKLM,

        /// <summary>
        /// HKEY_CLASSES_ROOT
        /// </summary>
        HKCR,

        /// <summary>
        /// HKEY_USERS
        /// </summary>
        HKU,

        /// <summary>
        /// HKEY_CURRENT_CONFIG
        /// </summary>
        HKCC,

        /// <summary>
        /// Equals <see cref="HKLM"/> in administrative install mode, <see cref="HKCU"/> otherwise.
        /// </summary>
        HKA
    }
}