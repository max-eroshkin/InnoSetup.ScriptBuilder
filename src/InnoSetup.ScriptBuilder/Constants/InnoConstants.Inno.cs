namespace InnoSetup.ScriptBuilder
{
    using System;

    public static partial class InnoConstants
    {
        public static class Inno
        {
            /// <summary>
            /// The full pathname of the system's standard command interpreter, Windows\System32\cmd.exe.
            /// Note that the COMSPEC environment variable is not used when expanding this constant.
            /// </summary>
            public const string Cmd = "{cmd}";

            /// <summary>
            /// The name of the computer the Setup or Uninstall program is running on
            /// (as returned by the Windows GetComputerName function).
            /// </summary>
            public const string ComputerName = "{computername}";

            /// <summary>
            /// The name of the folder the user selected on Setup's Select Start Menu Folder wizard page.
            /// This differs from {group} in that it is only the name; it does not include a path.
            /// </summary>
            public const string GroupName = "{groupname}";

            /// <summary>
            /// (Special-purpose) Translates to the window handle of the Setup program's background window.
            /// </summary>
            /// <remarks>
            /// Removed in Inno Setup 6.4: use <see cref="WizardHwnd"/> instead.
            /// </remarks>
            [Obsolete("Removed in Inno Setup 6.4")]
            public const string Hwnd = "{hwnd}";

            /// <summary>
            /// (Special-purpose) Translates to the window handle of the Setup wizard window. This handle is set to '0'
            /// if the window handle isn't available at the time the translation is done.
            /// </summary>
            public const string WizardHwnd = "{wizardhwnd}";

            /// <summary>
            /// The internal name of the selected language. See the [Languages] section documentation for more information.
            /// </summary>
            public const string Language = "{language}";

            /// <summary>
            /// The full pathname of the Setup program file, e.g. "C:\SETUP.EXE".
            /// </summary>
            public const string SrcExe = "{srcexe}";

            /// <summary>
            /// The full pathname of the uninstall program extracted by Setup,
            /// e.g. "C:\Program Files\My Program\unins000.exe". This constant is typically used in an [Icons] section entry
            /// for creating an Uninstall icon. It is only valid if Uninstallable is yes (the default setting).
            /// </summary>
            public const string UninstallExe = "{uninstallexe}";

            /// <summary>
            /// The user name that Windows is registered to. This information is read from the registry.
            /// </summary>
            public const string SysUserInfoName = "{sysuserinfoname}";

            /// <summary>
            /// The user organization that Windows is registered to. This information is read from the registry.
            /// </summary>
            public const string SysUserInfoOrg = "{sysuserinfoorg}";

            /// <summary>
            /// The name that the user entered on the User Information wizard page (which can be enabled via the UserInfoPage directive). Typically, these constants are used in [Registry] or [INI] entries to save their values for later use.
            /// </summary>
            public const string UserInfoName = "{userinfoname}";

            /// <summary>
            /// The organization that the user entered on the User Information wizard page (which can be enabled via the UserInfoPage directive). Typically, these constants are used in [Registry] or [INI] entries to save their values for later use.
            /// </summary>
            public const string UserInfoOrg = "{userinfoorg}";

            /// <summary>
            /// The serial number that the user entered on the User Information wizard page (which can be enabled via the UserInfoPage directive). Typically, these constants are used in [Registry] or [INI] entries to save their values for later use.
            /// </summary>
            public const string UserInfoSerial = "{userinfoserial}";

            /// <summary>
            /// The name of the user who is running Setup or Uninstall program (as returned by the GetUserName function).
            /// </summary>
            public const string UserName = "{username}";

            /// <summary>
            /// The log file name, or an empty string if logging is not enabled.
            /// </summary>
            public const string Log = "{log}";

            /// <summary>
            /// Returns the constant representing the value of an environment variable.
            /// </summary>
            /// <param name="variableName">The name of the environment variable to use.</param>
            /// <param name="defaultValue">The string to embed if the specified variable does not exist
            /// on the user's system. </param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>
            /// {%COMSPEC}
            /// {%PROMPT|$P$G}
            /// </example>
            public static string GetEnvironmentVariable(string variableName, string defaultValue = null)
            {
                if (!string.IsNullOrWhiteSpace(defaultValue))
                    variableName += "|" + defaultValue;
                return $"{{%{variableName}}}";
            }

            /// <summary>
            /// Returns the constant of a value from an .INI file.
            /// </summary>
            /// <param name="filename">The name of the .INI file to read from.</param>
            /// <param name="section">The name of the section to read from.</param>
            /// <param name="key">The name of the key to read.</param>
            /// <param name="defaultValue">The string to embed if the specified key does not exist.</param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>{ini:{win}\MyProg.ini,Settings,Path|{autopf}\My Program}</example>
            public static string GetIniVariable(
                string filename,
                string section,
                string key,
                string defaultValue = null)
            {
                var val = $"{filename},{section},{key}";
                if (!string.IsNullOrWhiteSpace(defaultValue))
                    val += "|" + defaultValue;
                return $"{{ini:{val}}}";
            }

            /// <summary>
            /// Returns the constant of a custom message value based on the active language.
            /// </summary>
            /// <param name="messageName">The name of custom message to read from.
            /// See the [CustomMessages] section documentation for more information.</param>
            /// <param name="arguments">Optionally specifies a comma separated list of arguments to the message value.</param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>{cm:LaunchProgram,Inno Setup}</example>
            public static string GetCustomMessage(string messageName, params string[] arguments)
            {
                return arguments.Length == 0
                    ? $"{{cm:{messageName}}}"
                    : $"{{cm:{messageName},{string.Join(",", arguments)}}}";
            }

            /// <summary>
            /// Returns the constant of a registry value.
            /// </summary>
            /// <param name="key">The root key.</param>
            /// <param name="subkey">The name of the subkey to read from.</param>
            /// <param name="valueName">The name of the value to read.
            /// Leave <paramref name="valueName"/> blank if you wish to read the "default" value of a key.</param>
            /// <param name="defaultValue">The string to embed if the specified registry value does not exist,
            /// or is not a string type (REG_SZ or REG_EXPAND_SZ).</param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>{reg:HKA\Software\My Program,Path|{autopf}\My Program}</example>
            public static string GetRegValue(
                RegistryKeys key,
                string subkey,
                string valueName = null,
                string defaultValue = null)
            {
                valueName ??= string.Empty;
                var val = $"{key}\\{subkey}";
                if (!string.IsNullOrWhiteSpace(valueName))
                    val += "," + valueName;
                if (!string.IsNullOrWhiteSpace(defaultValue))
                    val += "|" + defaultValue;
                return $"{{reg:{val}}}";
            }

            /// <summary>
            /// Returns the constant of a command line parameter value.
            /// </summary>
            /// <param name="parameterName">The name of the command line parameter to read from.</param>
            /// <param name="defaultValue">
            /// The string to embed if the specified command line parameter does not exist,
            /// or its value could not be determined.</param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>{param:Path|{autopf}\My Program}</example>
            public static string GetCommandLineParameter(string parameterName, string defaultValue = null)
            {
                if (!string.IsNullOrWhiteSpace(defaultValue))
                    parameterName += "|" + defaultValue;
                return $"{{param:{parameterName}}}";
            }

            /// <summary>
            /// Returns the constant of a function result from Code section.
            /// </summary>
            /// <param name="functionName">The name of the function from Code section.</param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>{code:GetItemName}</example>
            public static string GetCodeResult(string functionName)
            {
                return $"{{code:{functionName}}}";
            }

            /// <summary>
            /// Returns the constant of the extracted drive letter and colon (e.g. "C:") from the specified path.
            /// In the case of a UNC path, it returns the server and share name (e.g. "\\SERVER\SHARE").
            /// </summary>
            /// <param name="path">The path.</param>
            /// <remarks>
            /// If you wish to include a comma, vertical bar ("|"), or closing brace ("}") inside the constant, you must
            /// escape it via "%-encoding." Replace the character with a "%" character, followed by its two-digit hex code.
            /// A comma is "%2c", a vertical bar is "%7c", and a closing brace is "%7d". If you want to include
            /// an actual "%" character, use "%25".
            /// </remarks>
            /// <example>
            /// {drive:{src}}
            /// {drive:c:\path\file}
            /// {drive:\\server\share\path\file}
            /// </example>
            public static string GetDrive(string path)
            {
                return $"{{drive:{path}}}";
            }
        }
    }
}
