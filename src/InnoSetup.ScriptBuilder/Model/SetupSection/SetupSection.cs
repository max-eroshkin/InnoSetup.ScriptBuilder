namespace InnoSetup.ScriptBuilder;

using System;

public class SetupSection : KeyValueSection
{
    public string AppName { get; set; }

    public string AppVerName { get; set; }

    public string AppId { get; set; }

    public string AppCopyright { get; set; }

    public string AppPublisher { get; set; }

    public string AppPublisherURL { get; set; }

    public string AppSupportPhone { get; set; }

    public string AppSupportURL { get; set; }

    public string AppUpdatesURL { get; set; }

    public string AppVersion { get; set; }

    public string DefaultDirName { get; set; }

    public string DefaultGroupName { get; set; }

    public string BaseFilename { get; set; }

    public string UninstallFilesDir { get; set; }

    public string UninstallDisplayName { get; set; }

    public string UninstallDisplayIcon { get; set; }

    public string AppMutex { get; set; }

    public string DefaultUserInfoName { get; set; }

    public string DefaultUserInfoOrg { get; set; }

    public string DefaultUserInfoSerial { get; set; }

    public string AppReadmeFile { get; set; }

    public string AppContact { get; set; }

    public string AppComments { get; set; }

    public string AppModifyPath { get; set; }

    public string CreateUninstallRegKey { get; set; }

    public YesNo? Uninstallable { get; set; }

    public string CloseApplicationsFilter { get; set; }

    /// <summary>
    /// A comma separated list of file name wildcards of files which should not be checked for being in use,
    /// even if they match <see cref="CloseApplicationsFilter"/>. Added in Inno Setup 6.4.2.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_closeapplicationsfilterexcludes">
    /// CloseApplicationsFilterExcludes
    /// </a>.
    /// </summary>
    public string CloseApplicationsFilterExcludes { get; set; }

    public string SetupMutex { get; set; }

    public YesNo? ChangesEnvironment { get; set; }

    public YesNo? ChangesAssociations { get; set; }

    public string InfoBeforeText { get; set; }

    public string LicenseText { get; set; }

    public string LicenseFile { get; set; }

    public string InfoAfterText { get; set; }

    public string CompiledCodeText { get; set; }

    public int? NumLanguageEntries { get; set; }

    public int? NumCustomMessageEntries { get; set; }

    public int? NumPermissionEntries { get; set; }

    public int? NumTypeEntries { get; set; }

    public int? NumComponentEntries { get; set; }

    public int? NumTaskEntries { get; set; }

    public int? NumDirEntries { get; set; }

    public int? NumFileEntries { get; set; }

    public int? NumFileLocationEntries { get; set; }

    public int? NumIconEntries { get; set; }

    public int? NumIniEntries { get; set; }

    public int? NumRegistryEntries { get; set; }

    public int? NumInstallDeleteEntries { get; set; }

    public int? NumUninstallDeleteEntries { get; set; }

    public int? NumRunEntries { get; set; }

    public int? NumUninstallRunEntries { get; set; }

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public long? BackColor { get; set; }

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public long? BackColor2 { get; set; }

    public YesNo? DirExistsWarning { get; set; }

    public YesNo? ShowLanguageDialog { get; set; }

    public UninstallLogMode? UninstallLogMode { get; set; }

    public WizardImageAlphaFormat? WizardImageAlphaFormat { get; set; }

    [Obsolete("Obsolete since Inno Setup 3.0.5: use WizardSizePercent (\"120,120\") instead")]
    public int? WizardSizePercentX { get; set; }

    [Obsolete("Obsolete since Inno Setup 3.0.5: use WizardSizePercent (\"120,120\") instead")]
    public int? WizardSizePercentY { get; set; }

    public long? ExtraDiskSpaceRequired { get; set; }

    public int? SlicesPerDisk { get; set; }

    public long? UninstallDisplaySize { get; set; }

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 5.0.0, because Setup and Uninstall
    /// are merged into a single executable.
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_uninstalliconfile">UninstallIconFile</a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 5.0.0: a custom Uninstall icon can no longer be set")]
    public string UninstallIconFile { get; set; }

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 3.0. Use the <c>{uninstallexe}</c> constant
    /// in an <c>[Icons]</c> section entry to create an Uninstall icon.
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_uninstalliconname">UninstallIconName</a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 3.0: use the {uninstallexe} constant in an [Icons] section entry instead")]
    public string UninstallIconName { get; set; }

    public YesNo? DisableDirPage { get; set; }

    public YesNo? DisableProgramGroupPage { get; set; }

    public YesNo? DisableWelcomePage { get; set; }

    public PrivilegesRequired? PrivilegesRequired { get; set; }

    public SetupPrivilegesRequiredOverrides? PrivilegesRequiredOverridesAllowed { get; set; }

    [Obsolete("Obsolete since Inno Setup 6.0: use the individual [Setup] directives instead")]
    public SetupOption? Options { get; set; }

    public string OutputDir { get; set; }

    public string OutputBaseFilename { get; set; }

    public string OutputManifestFile { get; set; }

    public string SetupIconFile { get; set; }

    public string WizardImageFile { get; set; }

    public string WizardSmallImageFile { get; set; }

    public YesNo? AllowCancelDuringInstall { get; set; }

    public YesNo? AllowNetworkDrive { get; set; }

    public YesNo? AllowNoIcons { get; set; }

    public YesNo? AllowRootDirectory { get; set; }

    public YesNo? AllowUNCPath { get; set; }

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 3.0. Use the <c>{uninstallexe}</c> constant
    /// in an <c>[Icons]</c> section entry to create an Uninstall icon.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_alwayscreateuninstallicon">
    /// AlwaysCreateUninstallIcon
    /// </a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 3.0: use the {uninstallexe} constant in an [Icons] section entry instead")]
    public string AlwaysCreateUninstallIcon { get; set; }

    public YesNo? AlwaysRestart { get; set; }

    public YesNo? AlwaysShowComponentsList { get; set; }

    public YesNo? AlwaysShowDirOnReadyPage { get; set; }

    public YesNo? AlwaysShowGroupOnReadyPage { get; set; }

    public YesNo? AlwaysUsePersonalGroup { get; set; }

    public YesNo? AppendDefaultDirName { get; set; }

    public YesNo? AppendDefaultGroupName { get; set; }

    /// <summary>
    /// Specifies the method of archive extraction used by the <c>extractarchive</c> <c>[Files]</c> flag.
    /// Added in Inno Setup 6.5; <see cref="ArchiveExtraction.Auto"/> was added in Inno Setup 7.0 and is the default.
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_archiveextraction">ArchiveExtraction</a>.
    /// </summary>
    public ArchiveExtraction? ArchiveExtraction { get; set; }

    public Architectures? ArchitecturesAllowed { get; set; }

    public ArchitecturesInstallIn64BitMode? ArchitecturesInstallIn64BitMode { get; set; }

    public YesNo? ASLRCompatible { get; set; }

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public BackColorDirection? BackColorDirection { get; set; }

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public YesNo? BackSolid { get; set; }

    public CloseApplications? CloseApplications { get; set; }

    public string Compression { get; set; }

    public uint? CompressionThreads { get; set; }

    public YesNo? CreateAppDir { get; set; }

    public string DefaultDialogFontName { get; set; }

    public YesNo? DEPCompatible { get; set; }

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 4.1.2.
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_disableappenddir">DisableAppendDir</a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 4.1.2: this directive is no longer supported")]
    public string DisableAppendDir { get; set; }

    public YesNo? DisableFinishedPage { get; set; }

    /// <summary>
    /// Specifies the precompiled files whose verification by the compiler should be skipped.
    /// Added in Inno Setup 6.5.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_disableprecompiledfileverifications">
    /// DisablePrecompiledFileVerifications
    /// </a>.
    /// </summary>
    public PrecompiledFileVerifications? DisablePrecompiledFileVerifications { get; set; }

    public YesNo? DisableReadyMemo { get; set; }

    public YesNo? DisableReadyPage { get; set; }

    public YesNo? DisableStartupPrompt { get; set; }

    public uint? DiskClusterSize { get; set; }

    public uint? DiskSliceSize { get; set; }

    public YesNo? DiskSpanning { get; set; }

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 4.2.5.
    /// <c>MergeDuplicateFiles=no</c> is equivalent to <c>DontMergeDuplicateFiles=yes</c>.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_dontmergeduplicatefiles">
    /// DontMergeDuplicateFiles
    /// </a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 4.2.5: use MergeDuplicateFiles=no instead")]
    public string DontMergeDuplicateFiles { get; set; }

    public YesNo? EnableDirDoesntExistWarning { get; set; }

    /// <summary>
    /// Specifies whether the installation is encrypted. <see cref="EncryptionMode.Full"/> was added in
    /// Inno Setup 6.5.
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_encryption">Encryption</a>.
    /// </summary>
    public EncryptionMode? Encryption { get; set; }

    /// <summary>
    /// Specifies the key derivation function used to derive the encryption key from <see cref="Password"/>:
    /// <c>pbkdf2</c> or <c>pbkdf2/&lt;iterations&gt;</c>, where the default number of iterations is 220000.
    /// Added in Inno Setup 6.4.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_encryptionkeyderivation">
    /// EncryptionKeyDerivation
    /// </a>.
    /// </summary>
    public string EncryptionKeyDerivation { get; set; }

    public YesNo? FlatComponentsList { get; set; }

    public string InfoAfterFile { get; set; }

    public string InfoBeforeFile { get; set; }

    public string InternalCompressLevel { get; set; }

    public LanguageDetectionMethod? LanguageDetectionMethod { get; set; }

    public uint? LZMAAlgorithm { get; set; }

    public uint? LZMABlockSize { get; set; }

    public uint? LZMADictionarySize { get; set; }

    public LzmaMatchFinder? LZMAMatchFinder { get; set; }

    public uint? LZMANumBlockThreads { get; set; }

    public uint? LZMANumFastBytes { get; set; }

    public YesNo? LZMAUseSeparateProcess { get; set; }

    public YesNo? MergeDuplicateFiles { get; set; }

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 4.0.
    /// Use the <c>[Languages]</c> section to specify a custom messages file.
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_messagesfile">MessagesFile</a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 4.0: use the [Languages] section instead")]
    public string MessagesFile { get; set; }

    public string MinVersion { get; set; }

    public YesNo? MissingMessagesWarning { get; set; }

    public YesNo? MissingRunOnceIdsWarning { get; set; }

    public YesNo? NotRecognizedMessagesWarning { get; set; }

    public string OnlyBelowVersion { get; set; }

    public YesNo? Output { get; set; }

    public string Password { get; set; }

    /// <summary>
    /// Controls whether Setup attempts to enable Windows' RedirectionGuard mitigation on its own process.
    /// Added in Inno Setup 6.7; defaults to <c>yes</c>.
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_redirectionguard">RedirectionGuard</a>.
    /// </summary>
    public YesNo? RedirectionGuard { get; set; }

    public uint? ReserveBytes { get; set; }

    public YesNo? RestartApplications { get; set; }

    public YesNo? RestartIfNeededByRun { get; set; }

    public YesNo? SetupLogging { get; set; }

    public YesNo? ShowComponentSizes { get; set; }

    public YesNo? ShowTasksTreeLines { get; set; }

    [Obsolete("Has no effect since Inno Setup 6.0 (Unicode-only builds)")]
    public YesNo? ShowUndisplayableLanguages { get; set; }

    public YesNo? SignedUninstaller { get; set; }

    public string SignedUninstallerDir { get; set; }

    public string SignTool { get; set; }

    public uint? SignToolMinimumTimeBetween { get; set; }

    public uint? SignToolRetryCount { get; set; }

    public uint? SignToolRetryDelay { get; set; }

    public YesNo? SignToolRunMinimized { get; set; }

    public YesNo? SolidCompression { get; set; }

    public string SourceDir { get; set; }

    public YesNo? TerminalServicesAware { get; set; }

    public uint? TimeStampRounding { get; set; }

    public YesNo? TimeStampsInUTC { get; set; }

    public string TouchDate { get; set; }

    public string TouchTime { get; set; }

    public YesNo? UpdateUninstallLogAppName { get; set; }

    public YesNo? UninstallLogging { get; set; }

    public YesNo? UninstallRestartComputer { get; set; }

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 5.0.0.
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_uninstallstyle">UninstallStyle</a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 5.0.0: this directive is no longer supported")]
    public string UninstallStyle { get; set; }

    public YesNo? UsedUserAreasWarning { get; set; }

    public YesNo? UsePreviousAppDir { get; set; }

    public YesNo? UsePreviousGroup { get; set; }

    public YesNo? UsePreviousLanguage { get; set; }

    public YesNo? UsePreviousPrivileges { get; set; }

    public YesNo? UsePreviousSetupType { get; set; }

    public YesNo? UsePreviousTasks { get; set; }

    public YesNo? UsePreviousUserInfo { get; set; }

    public YesNo? UseSetupLdr { get; set; }

    public YesNo? UserInfoPage { get; set; }

    public string VersionInfoCompany { get; set; }

    public string VersionInfoCopyright { get; set; }

    public string VersionInfoDescription { get; set; }

    public string VersionInfoOriginalFileName { get; set; }

    public string VersionInfoProductName { get; set; }

    public string VersionInfoProductVersion { get; set; }

    public string VersionInfoProductTextVersion { get; set; }

    public string VersionInfoTextVersion { get; set; }

    public string VersionInfoVersion { get; set; }

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public YesNo? WindowResizable { get; set; }

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public YesNo? WindowShowCaption { get; set; }

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public YesNo? WindowStartMaximized { get; set; }

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public YesNo? WindowVisible { get; set; }

    /// <summary>
    /// Specifies the background color to use for wizard pages and all other windows such as the
    /// <i>Select Language</i> dialog, in both Setup and Uninstall. Added in Inno Setup 6.7.
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardbackcolor">WizardBackColor</a>.
    /// </summary>
    public IssColor? WizardBackColor { get; set; }

    /// <summary>
    /// Overrides <see cref="WizardBackColor"/> when <see cref="WizardStyle"/> uses the <c>dynamic</c> mode and
    /// Windows is in dark mode. Added in Inno Setup 6.7.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardbackcolordynamicdark">
    /// WizardBackColorDynamicDark
    /// </a>.
    /// </summary>
    public IssColor? WizardBackColorDynamicDark { get; set; }

    /// <summary>
    /// Specifies a custom image to display as the background of wizard pages in Setup, but not in Uninstall.
    /// Added in Inno Setup 6.7.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardbackimagefile">WizardBackImageFile</a>.
    /// </summary>
    public string WizardBackImageFile { get; set; }

    /// <summary>
    /// Overrides <see cref="WizardBackImageFile"/> when <see cref="WizardStyle"/> uses the <c>dynamic</c> mode and
    /// Windows is in dark mode. Added in Inno Setup 6.7.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardbackimagefiledynamicdark">
    /// WizardBackImageFileDynamicDark
    /// </a>.
    /// </summary>
    public string WizardBackImageFileDynamicDark { get; set; }

    /// <summary>
    /// Specifies the opacity of the background wizard image, from <c>0</c> (fully transparent) to <c>255</c>
    /// (fully opaque, the default). Added in Inno Setup 6.7.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardbackimageopacity">
    /// WizardBackImageOpacity
    /// </a>.
    /// </summary>
    public int? WizardBackImageOpacity { get; set; }

    /// <summary>
    /// Specifies the background color used to fill any unused or transparent space around
    /// <see cref="WizardImageFile"/>; <c>none</c> keeps transparency.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardimagebackcolor">WizardImageBackColor</a>.
    /// </summary>
    public IssColor? WizardImageBackColor { get; set; }

    /// <summary>
    /// Overrides <see cref="WizardImageBackColor"/> when <see cref="WizardStyle"/> uses the <c>dynamic</c> mode and
    /// Windows is in dark mode. Added in Inno Setup 6.6.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardimagebackcolordynamicdark">
    /// WizardImageBackColorDynamicDark
    /// </a>.
    /// </summary>
    public IssColor? WizardImageBackColorDynamicDark { get; set; }

    /// <summary>
    /// Overrides <see cref="WizardImageFile"/> when <see cref="WizardStyle"/> uses the <c>dynamic</c> mode and
    /// Windows is in dark mode. Added in Inno Setup 6.6.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardimagefiledynamicdark">
    /// WizardImageFileDynamicDark
    /// </a>.
    /// </summary>
    public string WizardImageFileDynamicDark { get; set; }

    /// <summary>
    /// Specifies the opacity of the wizard images, from <c>0</c> (fully transparent) to <c>255</c>
    /// (fully opaque, the default). Added in Inno Setup 6.6.1.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardimageopacity">WizardImageOpacity</a>.
    /// </summary>
    public int? WizardImageOpacity { get; set; }

    public YesNo? WizardImageStretch { get; set; }

    /// <summary>
    /// Specifies whether Setup and Uninstall keep the original aspect ratio of their windows when scaling
    /// for DPI. Added in Inno Setup 6.6; defaults to <c>yes</c>.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardkeepaspectratio">WizardKeepAspectRatio</a>.
    /// </summary>
    public YesNo? WizardKeepAspectRatio { get; set; }

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public YesNo? WizardResizable { get; set; }

    public string WizardSizePercent { get; set; }

    /// <summary>
    /// Specifies the background color used to fill any unused or transparent space around
    /// <see cref="WizardSmallImageFile"/>; <c>none</c> keeps transparency.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardsmallimagebackcolor">
    /// WizardSmallImageBackColor
    /// </a>.
    /// </summary>
    public IssColor? WizardSmallImageBackColor { get; set; }

    /// <summary>
    /// Overrides <see cref="WizardSmallImageBackColor"/> when <see cref="WizardStyle"/> uses the <c>dynamic</c>
    /// mode and Windows is in dark mode. Added in Inno Setup 6.6.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardsmallimagebackcolordynamicdark">
    /// WizardSmallImageBackColorDynamicDark
    /// </a>.
    /// </summary>
    public IssColor? WizardSmallImageBackColorDynamicDark { get; set; }

    /// <summary>
    /// Overrides <see cref="WizardSmallImageFile"/> when <see cref="WizardStyle"/> uses the <c>dynamic</c> mode and
    /// Windows is in dark mode. Added in Inno Setup 6.6.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardsmallimagefiledynamicdark">
    /// WizardSmallImageFileDynamicDark
    /// </a>.
    /// </summary>
    public string WizardSmallImageFileDynamicDark { get; set; }

    public WizardStyle? WizardStyle { get; set; }

    /// <summary>
    /// Specifies a custom VCL Styles file (<c>.vsf</c>) to be used as the default style, or one of
    /// <c>builtin:polar</c>, <c>builtin:slate</c>, <c>builtin:stellar</c> and <c>builtin:zircon</c>.
    /// Added in Inno Setup 6.6.
    /// See <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardstylefile">WizardStyleFile</a>.
    /// </summary>
    public string WizardStyleFile { get; set; }

    /// <summary>
    /// Overrides <see cref="WizardStyleFile"/> when <see cref="WizardStyle"/> uses the <c>dynamic</c> mode and
    /// Windows is in dark mode. Added in Inno Setup 6.6.
    /// See
    /// <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardstylefiledynamicdark">
    /// WizardStyleFileDynamicDark
    /// </a>.
    /// </summary>
    public string WizardStyleFileDynamicDark { get; set; }
}