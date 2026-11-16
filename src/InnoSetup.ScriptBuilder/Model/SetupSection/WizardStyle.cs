namespace InnoSetup.ScriptBuilder;

using System;

/// <summary>
/// Specifies the visual style and appearance of Setup and Uninstall, as set by the <c>WizardStyle</c>
/// directive. Combine the base styles, the appearance modes, the built-in custom styles and the modifiers
/// with <c>|</c>, for example <c>WizardStyle.Modern | WizardStyle.Dark | WizardStyle.Dynamic</c>.
/// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardstyle">WizardStyle</a>.
/// </summary>
[Flags]
public enum WizardStyle
{
    /// <summary>
    /// Uses a gray background for the page content. This is the default base style.
    /// </summary>
    Classic = 1,

    /// <summary>
    /// Uses a white background for the page content, matching the top panel, and hides the bevel
    /// between the top panel and the page content.
    /// </summary>
    Modern = 1 << 1,

    /// <summary>
    /// Forces a light appearance. This is the default appearance mode.
    /// </summary>
    Light = 1 << 2,

    /// <summary>
    /// Forces a dark appearance.
    /// </summary>
    Dark = 1 << 3,

    /// <summary>
    /// Automatically switches between the light and dark appearance based on the Windows system settings.
    /// </summary>
    Dynamic = 1 << 4,

    /// <summary>
    /// Uses light blue instead of gray or white for the light appearance, and dark blue instead of black
    /// for the dark appearance.
    /// </summary>
    Polar = 1 << 5,

    /// <summary>
    /// Uses medium gray for both the light and dark appearances.
    /// </summary>
    Slate = 1 << 6,

    /// <summary>
    /// Alternative light-only style with white foreground text, ideally suited to be combined with a custom
    /// darker background color or image.
    /// </summary>
    Stellar = 1 << 7,

    /// <summary>
    /// Enables a light counterpart of the built-in dark style.
    /// </summary>
    Windows11 = 1 << 8,

    /// <summary>
    /// Alternative light-only style with cyan accents.
    /// </summary>
    Zircon = 1 << 9,

    /// <summary>
    /// Disables custom styling of all buttons (including command link buttons) when a light style is active.
    /// </summary>
    ExcludeLightButtons = 1 << 10,

    /// <summary>
    /// Disables custom styling of all controls (including buttons) when a light style is active, except when
    /// styling is required to achieve transparency.
    /// </summary>
    ExcludeLightControls = 1 << 11,

    /// <summary>
    /// Hides all bevels (horizontal lines) across Setup and Uninstall, except those in native system dialogs.
    /// </summary>
    HideBevels = 1 << 12,

    /// <summary>
    /// Enables custom styling of both title bars and borders when a custom style is active.
    /// </summary>
    IncludeTitleBar = 1 << 13
}
