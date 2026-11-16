namespace InnoSetup.ScriptBuilder;

using System;
using System.Globalization;

public class SetupBuilder : KeyValueSectionBuilderBase<SetupBuilder, SetupSection>, ISetupBuilder
{
    public override string SectionName => "Setup";

    public SetupBuilder Create(string appName)
    {
        CreateEntryInternal();
        return AppName(appName);
    }

    public SetupBuilder AppVerName(string value) => SetPropertyValue(value);
    public SetupBuilder AppId(string value) => SetPropertyValue(value);
    public SetupBuilder AppCopyright(string value) => SetPropertyValue(value);
    public SetupBuilder AppPublisher(string value) => SetPropertyValue(value);
    public SetupBuilder AppPublisherURL(string value) => SetPropertyValue(value);
    public SetupBuilder AppSupportPhone(string value) => SetPropertyValue(value);
    public SetupBuilder AppSupportURL(string value) => SetPropertyValue(value);
    public SetupBuilder AppUpdatesURL(string value) => SetPropertyValue(value);
    public SetupBuilder AppVersion(string value) => SetPropertyValue(value);
    public SetupBuilder DefaultDirName(string value) => SetPropertyValue(value);
    public SetupBuilder DefaultGroupName(string value) => SetPropertyValue(value);
    public SetupBuilder BaseFilename(string value) => SetPropertyValue(value);
    public SetupBuilder UninstallFilesDir(string value) => SetPropertyValue(value);
    public SetupBuilder UninstallDisplayName(string value) => SetPropertyValue(value);
    public SetupBuilder UninstallDisplayIcon(string value) => SetPropertyValue(value);
    public SetupBuilder AppMutex(string value) => SetPropertyValue(value);
    public SetupBuilder DefaultUserInfoName(string value) => SetPropertyValue(value);
    public SetupBuilder DefaultUserInfoOrg(string value) => SetPropertyValue(value);
    public SetupBuilder DefaultUserInfoSerial(string value) => SetPropertyValue(value);
    public SetupBuilder AppReadmeFile(string value) => SetPropertyValue(value);
    public SetupBuilder AppContact(string value) => SetPropertyValue(value);
    public SetupBuilder AppComments(string value) => SetPropertyValue(value);
    public SetupBuilder AppModifyPath(string value) => SetPropertyValue(value);

    /// <summary>
    /// Controls whether Setup creates an entry in the <i>Add/Remove Programs</i> Control Panel applet.
    /// Accepts <c>yes</c>, <c>no</c> or a scripted boolean expression.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_createuninstallregkey">CreateUninstallRegKey</a>.
    /// </summary>
    public SetupBuilder CreateUninstallRegKey(IssYesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Controls whether Inno Setup's automatic uninstaller is included in the installation.
    /// Accepts <c>yes</c>, <c>no</c> or a scripted boolean expression.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_uninstallable">Uninstallable</a>.
    /// </summary>
    public SetupBuilder Uninstallable(IssYesNo value) => SetPropertyValue(value);

    public SetupBuilder CloseApplicationsFilter(string value) => SetPropertyValue(value);

    /// <summary>
    /// A comma separated list of file name wildcards of files which should not be checked for being in use,
    /// even if they match <c>CloseApplicationsFilter</c>. Added in Inno Setup 6.4.2.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_closeapplicationsfilterexcludes">
    /// CloseApplicationsFilterExcludes
    /// </a>.
    /// </summary>
    public SetupBuilder CloseApplicationsFilterExcludes(string value) => SetPropertyValue(value);

    public SetupBuilder SetupMutex(string value) => SetPropertyValue(value);

    /// <summary>
    /// Controls whether Setup notifies other running applications that they should reload their
    /// environment variables from the registry at the end of the installation. Accepts <c>yes</c>, <c>no</c>
    /// or a scripted boolean expression.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_changesenvironment">ChangesEnvironment</a>.
    /// </summary>
    public SetupBuilder ChangesEnvironment(IssYesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Controls whether Setup tells Explorer to refresh its file associations information at the end of the
    /// installation. Accepts <c>yes</c>, <c>no</c> or a scripted boolean expression.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_changesassociations">ChangesAssociations</a>.
    /// </summary>
    public SetupBuilder ChangesAssociations(IssYesNo value) => SetPropertyValue(value);

    public SetupBuilder InfoBeforeText(string value) => SetPropertyValue(value);
    public SetupBuilder LicenseText(string value) => SetPropertyValue(value);
    public SetupBuilder LicenseFile(string value) => SetPropertyValue(value);
    public SetupBuilder InfoAfterText(string value) => SetPropertyValue(value);
    public SetupBuilder CompiledCodeText(string value) => SetPropertyValue(value);
    public SetupBuilder NumLanguageEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumCustomMessageEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumPermissionEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumTypeEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumComponentEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumTaskEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumDirEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumFileEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumFileLocationEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumIconEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumIniEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumRegistryEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumInstallDeleteEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumUninstallDeleteEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumRunEntries(int value) => SetPropertyValue(value);
    public SetupBuilder NumUninstallRunEntries(int value) => SetPropertyValue(value);

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public SetupBuilder BackColor(long value) => SetPropertyValue(value);

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public SetupBuilder BackColor2(long value) => SetPropertyValue(value);

    public SetupBuilder DirExistsWarning(YesNo value) => SetPropertyValue(value);
    public SetupBuilder ShowLanguageDialog(YesNo value) => SetPropertyValue(value);
    public SetupBuilder UninstallLogMode(UninstallLogMode value) => SetPropertyValue(value);
    public SetupBuilder WizardImageAlphaFormat(WizardImageAlphaFormat value) => SetPropertyValue(value);

    [Obsolete("Obsolete since Inno Setup 3.0.5: use WizardSizePercent (\"120,120\") instead")]
    public SetupBuilder WizardSizePercentX(int value) => SetPropertyValue(value);

    [Obsolete("Obsolete since Inno Setup 3.0.5: use WizardSizePercent (\"120,120\") instead")]
    public SetupBuilder WizardSizePercentY(int value) => SetPropertyValue(value);

    public SetupBuilder ExtraDiskSpaceRequired(long value) => SetPropertyValue(value);
    public SetupBuilder SlicesPerDisk(int value) => SetPropertyValue(value);
    public SetupBuilder UninstallDisplaySize(long value) => SetPropertyValue(value);

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 5.0.0, because Setup and Uninstall
    /// are merged into a single executable.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_uninstalliconfile">UninstallIconFile</a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 5.0.0: a custom Uninstall icon can no longer be set")]
    public SetupBuilder UninstallIconFile(string value) => SetPropertyValue(value);

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 3.0. Use the <c>{uninstallexe}</c> constant
    /// in an <c>[Icons]</c> section entry to create an Uninstall icon.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_uninstalliconname">UninstallIconName</a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 3.0: use the {uninstallexe} constant in an [Icons] section entry instead")]
    public SetupBuilder UninstallIconName(string value) => SetPropertyValue(value);

    public SetupBuilder DisableDirPage(YesNo value) => SetPropertyValue(value);
    public SetupBuilder DisableProgramGroupPage(YesNo value) => SetPropertyValue(value);
    public SetupBuilder DisableWelcomePage(YesNo value) => SetPropertyValue(value);
    public SetupBuilder PrivilegesRequired(PrivilegesRequired value) => SetPropertyValue(value);

    public SetupBuilder PrivilegesRequiredOverridesAllowed(SetupPrivilegesRequiredOverrides value) =>
        SetPropertyValue(value);

    [Obsolete("Obsolete since Inno Setup 6.0: use the individual [Setup] directives instead")]
    public SetupBuilder Options(SetupOption value) => SetPropertyValue(value);

    public SetupBuilder OutputDir(string value) => SetPropertyValue(value);
    public SetupBuilder OutputBaseFilename(string value) => SetPropertyValue(value);
    public SetupBuilder OutputManifestFile(string value) => SetPropertyValue(value);
    public SetupBuilder SetupIconFile(string value) => SetPropertyValue(value);
    public SetupBuilder WizardImageFile(string value) => SetPropertyValue(value);
    public SetupBuilder WizardSmallImageFile(string value) => SetPropertyValue(value);

    public SetupBuilder AllowCancelDuringInstall(YesNo value) => SetPropertyValue(value);

    public SetupBuilder AllowNetworkDrive(YesNo value) => SetPropertyValue(value);

    public SetupBuilder AllowNoIcons(YesNo value) => SetPropertyValue(value);

    public SetupBuilder AllowRootDirectory(YesNo value) => SetPropertyValue(value);

    public SetupBuilder AllowUNCPath(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 3.0. Use the <c>{uninstallexe}</c> constant
    /// in an <c>[Icons]</c> section entry to create an Uninstall icon.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_alwayscreateuninstallicon">
    /// AlwaysCreateUninstallIcon
    /// </a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 3.0: use the {uninstallexe} constant in an [Icons] section entry instead")]
    public SetupBuilder AlwaysCreateUninstallIcon(string value) => SetPropertyValue(value);

    public SetupBuilder AlwaysRestart(YesNo value) => SetPropertyValue(value);

    public SetupBuilder AlwaysShowComponentsList(YesNo value) => SetPropertyValue(value);

    public SetupBuilder AlwaysShowDirOnReadyPage(YesNo value) => SetPropertyValue(value);

    public SetupBuilder AlwaysShowGroupOnReadyPage(YesNo value) => SetPropertyValue(value);

    public SetupBuilder AlwaysUsePersonalGroup(YesNo value) => SetPropertyValue(value);

    public SetupBuilder AppendDefaultDirName(YesNo value) => SetPropertyValue(value);

    public SetupBuilder AppendDefaultGroupName(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the method of archive extraction used by the <c>extractarchive</c> <c>[Files]</c> flag.
    /// Added in Inno Setup 6.5; <see cref="ArchiveExtraction.Auto"/> was added in Inno Setup 7.0 and is the default.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_archiveextraction">ArchiveExtraction</a>.
    /// </summary>
    public SetupBuilder ArchiveExtraction(ArchiveExtraction value) => SetPropertyValue(value);

    public SetupBuilder ArchitecturesAllowed(Architectures value) => SetPropertyValue(value);

    public SetupBuilder ArchitecturesInstallIn64BitMode(ArchitecturesInstallIn64BitMode value) =>
        SetPropertyValue(value);

    public SetupBuilder ASLRCompatible(YesNo value) => SetPropertyValue(value);

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public SetupBuilder BackColorDirection(BackColorDirection value) => SetPropertyValue(value);

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public SetupBuilder BackSolid(YesNo value) => SetPropertyValue(value);

    public SetupBuilder CloseApplications(CloseApplications value) => SetPropertyValue(value);

    public SetupBuilder Compression(string value) => SetPropertyValue(value);

    public SetupBuilder CompressionThreads(uint value) => SetPropertyValue(value);

    public SetupBuilder CreateAppDir(YesNo value) => SetPropertyValue(value);

    public SetupBuilder DefaultDialogFontName(string value) => SetPropertyValue(value);

    public SetupBuilder DEPCompatible(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 4.1.2.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_disableappenddir">DisableAppendDir</a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 4.1.2: this directive is no longer supported")]
    public SetupBuilder DisableAppendDir(string value) => SetPropertyValue(value);

    public SetupBuilder DisableFinishedPage(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the precompiled files whose verification by the compiler should be skipped.
    /// Added in Inno Setup 6.5.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_disableprecompiledfileverifications">
    /// DisablePrecompiledFileVerifications
    /// </a>.
    /// </summary>
    public SetupBuilder DisablePrecompiledFileVerifications(PrecompiledFileVerifications value) =>
        SetPropertyValue(value);

    public SetupBuilder DisableReadyMemo(YesNo value) => SetPropertyValue(value);

    public SetupBuilder DisableReadyPage(YesNo value) => SetPropertyValue(value);

    public SetupBuilder DisableStartupPrompt(YesNo value) => SetPropertyValue(value);

    public SetupBuilder DiskClusterSize(uint value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the maximum number of bytes per disk slice (<c>Setup-*.bin</c> file): <c>262144</c> through
    /// <c>9223372036800000000</c>. The upper limit was raised in Inno Setup 7.0 for 64-bit Setup.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_diskslicesize">DiskSliceSize</a>.
    /// </summary>
    public SetupBuilder DiskSliceSize(ulong value) => SetPropertyValue(value);

    public SetupBuilder DiskSpanning(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 4.2.5.
    /// <c>MergeDuplicateFiles=no</c> is equivalent to <c>DontMergeDuplicateFiles=yes</c>.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_dontmergeduplicatefiles">
    /// DontMergeDuplicateFiles
    /// </a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 4.2.5: use MergeDuplicateFiles=no instead")]
    public SetupBuilder DontMergeDuplicateFiles(string value) => SetPropertyValue(value);

    public SetupBuilder EnableDirDoesntExistWarning(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies whether the installation is encrypted. <see cref="EncryptionMode.Full"/> was added in
    /// Inno Setup 6.5.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_encryption">Encryption</a>.
    /// </summary>
    public SetupBuilder Encryption(EncryptionMode value) => SetPropertyValue(value);

    /// <summary>
    /// Uses the default PBKDF2-HMAC-SHA256 key derivation function with its default number of iterations
    /// (220000), which is the same as <c>EncryptionKeyDerivation=pbkdf2</c>.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_encryptionkeyderivation">
    /// EncryptionKeyDerivation
    /// </a>.
    /// </summary>
    public SetupBuilder EncryptionKeyDerivation() => EncryptionKeyDerivation("pbkdf2");

    /// <summary>
    /// Uses the PBKDF2-HMAC-SHA256 key derivation function with the given number of iterations, which is
    /// written as <c>pbkdf2/&lt;iterations&gt;</c>. Added in Inno Setup 6.4.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_encryptionkeyderivation">
    /// EncryptionKeyDerivation
    /// </a>.
    /// </summary>
    /// <param name="iterations">The number of iterations, 1 through 2147483647.</param>
    /// <exception cref="ArgumentOutOfRangeException">The value is outside the 1-2147483647 range.</exception>
    public SetupBuilder EncryptionKeyDerivation(int iterations)
    {
        if (iterations < 1)
            throw new ArgumentOutOfRangeException(
                nameof(iterations),
                iterations,
                "The number of iterations must be in the 1-2147483647 range.");

        return EncryptionKeyDerivation($"pbkdf2/{iterations.ToString(CultureInfo.InvariantCulture)}");
    }

    /// <summary>
    /// Uses the given key derivation function definition as-is, typically <c>pbkdf2</c> or
    /// <c>pbkdf2/&lt;iterations&gt;</c>. Added in Inno Setup 6.4.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_encryptionkeyderivation">
    /// EncryptionKeyDerivation
    /// </a>.
    /// </summary>
    public SetupBuilder EncryptionKeyDerivation(string value) => SetPropertyValue(value);

    public SetupBuilder FlatComponentsList(YesNo value) => SetPropertyValue(value);

    public SetupBuilder InfoAfterFile(string value) => SetPropertyValue(value);

    public SetupBuilder InfoBeforeFile(string value) => SetPropertyValue(value);

    public SetupBuilder InternalCompressLevel(string value) => SetPropertyValue(value);

    public SetupBuilder LanguageDetectionMethod(LanguageDetectionMethod value) => SetPropertyValue(value);

    public SetupBuilder LZMAAlgorithm(uint value) => SetPropertyValue(value);

    public SetupBuilder LZMABlockSize(uint value) => SetPropertyValue(value);

    public SetupBuilder LZMADictionarySize(uint value) => SetPropertyValue(value);

    public SetupBuilder LZMAMatchFinder(LzmaMatchFinder value) => SetPropertyValue(value);

    public SetupBuilder LZMANumBlockThreads(uint value) => SetPropertyValue(value);

    public SetupBuilder LZMANumFastBytes(uint value) => SetPropertyValue(value);

    public SetupBuilder LZMAUseSeparateProcess(YesNo value) => SetPropertyValue(value);

    public SetupBuilder MergeDuplicateFiles(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 4.0.
    /// Use the <c>[Languages]</c> section to specify a custom messages file.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_messagesfile">MessagesFile</a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 4.0: use the [Languages] section instead")]
    public SetupBuilder MessagesFile(string value) => SetPropertyValue(value);

    public SetupBuilder MinVersion(string value) => SetPropertyValue(value);

    public SetupBuilder MissingMessagesWarning(YesNo value) => SetPropertyValue(value);

    public SetupBuilder MissingRunOnceIdsWarning(YesNo value) => SetPropertyValue(value);

    public SetupBuilder NotRecognizedMessagesWarning(YesNo value) => SetPropertyValue(value);

    public SetupBuilder OnlyBelowVersion(string value) => SetPropertyValue(value);

    public SetupBuilder Output(YesNo value) => SetPropertyValue(value);

    public SetupBuilder Password(string value) => SetPropertyValue(value);

    /// <summary>
    /// Controls whether Setup attempts to enable Windows' RedirectionGuard mitigation on its own process.
    /// Added in Inno Setup 6.7; defaults to <c>yes</c>.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_redirectionguard">RedirectionGuard</a>.
    /// </summary>
    public SetupBuilder RedirectionGuard(YesNo value) => SetPropertyValue(value);

    public SetupBuilder ReserveBytes(uint value) => SetPropertyValue(value);

    public SetupBuilder RestartApplications(YesNo value) => SetPropertyValue(value);

    public SetupBuilder RestartIfNeededByRun(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the architecture of the Setup program itself: <c>x86</c> (the default) or <c>x64</c>.
    /// Added in Inno Setup 7.0.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_setuparchitecture">SetupArchitecture</a>.
    /// </summary>
    public SetupBuilder SetupArchitecture(SetupArchitecture value) => SetPropertyValue(value);

    public SetupBuilder SetupLogging(YesNo value) => SetPropertyValue(value);

    public SetupBuilder ShowComponentSizes(YesNo value) => SetPropertyValue(value);

    public SetupBuilder ShowTasksTreeLines(YesNo value) => SetPropertyValue(value);

    [Obsolete("Has no effect since Inno Setup 6.0 (Unicode-only builds)")]
    public SetupBuilder ShowUndisplayableLanguages(YesNo value) => SetPropertyValue(value);

    public SetupBuilder SignedUninstaller(YesNo value) => SetPropertyValue(value);

    public SetupBuilder SignedUninstallerDir(string value) => SetPropertyValue(value);

    public SetupBuilder SignTool(string value) => SetPropertyValue(value);

    public SetupBuilder SignToolMinimumTimeBetween(uint value) => SetPropertyValue(value);

    public SetupBuilder SignToolRetryCount(uint value) => SetPropertyValue(value);

    public SetupBuilder SignToolRetryDelay(uint value) => SetPropertyValue(value);

    public SetupBuilder SignToolRunMinimized(YesNo value) => SetPropertyValue(value);

    public SetupBuilder SolidCompression(YesNo value) => SetPropertyValue(value);

    public SetupBuilder SourceDir(string value) => SetPropertyValue(value);

    public SetupBuilder TerminalServicesAware(YesNo value) => SetPropertyValue(value);

    public SetupBuilder TimeStampRounding(uint value) => SetPropertyValue(value);

    public SetupBuilder TimeStampsInUTC(YesNo value) => SetPropertyValue(value);

    public SetupBuilder TouchDate(string value) => SetPropertyValue(value);

    public SetupBuilder TouchTime(string value) => SetPropertyValue(value);

    public SetupBuilder UpdateUninstallLogAppName(YesNo value) => SetPropertyValue(value);

    public SetupBuilder UninstallLogging(YesNo value) => SetPropertyValue(value);

    public SetupBuilder UninstallRestartComputer(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// No longer supported: the directive is obsolete since Inno Setup 5.0.0.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_uninstallstyle">UninstallStyle</a>.
    /// </summary>
    [Obsolete("Obsolete since Inno Setup 5.0.0: this directive is no longer supported")]
    public SetupBuilder UninstallStyle(string value) => SetPropertyValue(value);

    public SetupBuilder UsedUserAreasWarning(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Controls whether Setup reuses the installation directory of a previous installation as the default
    /// directory. Accepts <c>yes</c>, <c>no</c> or a scripted boolean expression.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_usepreviousappdir">UsePreviousAppDir</a>.
    /// </summary>
    public SetupBuilder UsePreviousAppDir(IssYesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Controls whether Setup reuses the Start menu folder name of a previous installation as the default.
    /// Accepts <c>yes</c>, <c>no</c> or a scripted boolean expression.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_usepreviousgroup">UsePreviousGroup</a>.
    /// </summary>
    public SetupBuilder UsePreviousGroup(IssYesNo value) => SetPropertyValue(value);

    public SetupBuilder UsePreviousLanguage(YesNo value) => SetPropertyValue(value);

    public SetupBuilder UsePreviousPrivileges(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Controls whether Setup reuses the setup type and component settings of a previous installation as the
    /// defaults. Accepts <c>yes</c>, <c>no</c> or a scripted boolean expression.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_useprevioussetuptype">UsePreviousSetupType</a>.
    /// </summary>
    public SetupBuilder UsePreviousSetupType(IssYesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Controls whether Setup reuses the task settings of a previous installation as the defaults. Accepts
    /// <c>yes</c>, <c>no</c> or a scripted boolean expression.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_useprevioustasks">UsePreviousTasks</a>.
    /// </summary>
    public SetupBuilder UsePreviousTasks(IssYesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Controls whether Setup reuses the name, organization and serial number entered previously as the
    /// default user information. Accepts <c>yes</c>, <c>no</c> or a scripted boolean expression.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_useprevioususerinfo">UsePreviousUserInfo</a>.
    /// </summary>
    public SetupBuilder UsePreviousUserInfo(IssYesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Tells the compiler which type of Setup to create. The <c>x86</c> and <c>x64</c> values were added in
    /// Inno Setup 6.7; when not set, the value matches <c>SetupArchitecture</c>.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_usesetupldr">UseSetupLdr</a>.
    /// </summary>
    public SetupBuilder UseSetupLdr(SetupLdrMode value) => SetPropertyValue(value);

    public SetupBuilder UserInfoPage(YesNo value) => SetPropertyValue(value);

    public SetupBuilder VersionInfoCompany(string value) => SetPropertyValue(value);

    public SetupBuilder VersionInfoCopyright(string value) => SetPropertyValue(value);

    public SetupBuilder VersionInfoDescription(string value) => SetPropertyValue(value);

    public SetupBuilder VersionInfoOriginalFileName(string value) => SetPropertyValue(value);

    public SetupBuilder VersionInfoProductName(string value) => SetPropertyValue(value);

    public SetupBuilder VersionInfoProductVersion(string value) => SetPropertyValue(value);

    public SetupBuilder VersionInfoProductTextVersion(string value) => SetPropertyValue(value);

    public SetupBuilder VersionInfoTextVersion(string value) => SetPropertyValue(value);

    public SetupBuilder VersionInfoVersion(string value) => SetPropertyValue(value);

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public SetupBuilder WindowResizable(YesNo value) => SetPropertyValue(value);

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public SetupBuilder WindowShowCaption(YesNo value) => SetPropertyValue(value);

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public SetupBuilder WindowStartMaximized(YesNo value) => SetPropertyValue(value);

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public SetupBuilder WindowVisible(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the background color to use for wizard pages and all other windows such as the
    /// <i>Select Language</i> dialog, in both Setup and Uninstall. Added in Inno Setup 6.7.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardbackcolor">WizardBackColor</a>.
    /// </summary>
    public SetupBuilder WizardBackColor(IssColor value) => SetPropertyValue(value);

    /// <summary>
    /// Overrides <c>WizardBackColor</c> when <c>WizardStyle</c> uses the <c>dynamic</c> mode and Windows is in
    /// dark mode. Added in Inno Setup 6.7.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardbackcolordynamicdark">
    /// WizardBackColorDynamicDark
    /// </a>.
    /// </summary>
    public SetupBuilder WizardBackColorDynamicDark(IssColor value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies a custom image to display as the background of wizard pages in Setup, but not in Uninstall.
    /// Added in Inno Setup 6.7.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardbackimagefile">WizardBackImageFile</a>.
    /// </summary>
    public SetupBuilder WizardBackImageFile(string value) => SetPropertyValue(value);

    /// <summary>
    /// Overrides <c>WizardBackImageFile</c> when <c>WizardStyle</c> uses the <c>dynamic</c> mode and Windows is in
    /// dark mode. Added in Inno Setup 6.7.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardbackimagefiledynamicdark">
    /// WizardBackImageFileDynamicDark
    /// </a>.
    /// </summary>
    public SetupBuilder WizardBackImageFileDynamicDark(string value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the opacity of the background wizard image, from <c>0</c> (fully transparent) to <c>255</c>
    /// (fully opaque, the default). Added in Inno Setup 6.7.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardbackimageopacity">
    /// WizardBackImageOpacity
    /// </a>.
    /// </summary>
    public SetupBuilder WizardBackImageOpacity(int value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the background color used to fill any unused or transparent space around
    /// <c>WizardImageFile</c>; <c>none</c> keeps transparency.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardimagebackcolor">WizardImageBackColor</a>.
    /// </summary>
    public SetupBuilder WizardImageBackColor(IssColor value) => SetPropertyValue(value);

    /// <summary>
    /// Overrides <c>WizardImageBackColor</c> when <c>WizardStyle</c> uses the <c>dynamic</c> mode and Windows is in
    /// dark mode. Added in Inno Setup 6.6.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardimagebackcolordynamicdark">
    /// WizardImageBackColorDynamicDark
    /// </a>.
    /// </summary>
    public SetupBuilder WizardImageBackColorDynamicDark(IssColor value) => SetPropertyValue(value);

    /// <summary>
    /// Overrides <c>WizardImageFile</c> when <c>WizardStyle</c> uses the <c>dynamic</c> mode and Windows is in
    /// dark mode. Added in Inno Setup 6.6.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardimagefiledynamicdark">
    /// WizardImageFileDynamicDark
    /// </a>.
    /// </summary>
    public SetupBuilder WizardImageFileDynamicDark(string value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the opacity of the wizard images, from <c>0</c> (fully transparent) to <c>255</c>
    /// (fully opaque, the default). Added in Inno Setup 6.6.1.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardimageopacity">WizardImageOpacity</a>.
    /// </summary>
    public SetupBuilder WizardImageOpacity(int value) => SetPropertyValue(value);

    public SetupBuilder WizardImageStretch(YesNo value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies whether Setup and Uninstall keep the original aspect ratio of their windows when scaling
    /// for DPI. Added in Inno Setup 6.6; defaults to <c>yes</c>.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardkeepaspectratio">WizardKeepAspectRatio</a>.
    /// </summary>
    public SetupBuilder WizardKeepAspectRatio(YesNo value) => SetPropertyValue(value);

    [Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")]
    public SetupBuilder WizardResizable(YesNo value) => SetPropertyValue(value);

    public SetupBuilder WizardSizePercent(string value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the background color used to fill any unused or transparent space around
    /// <c>WizardSmallImageFile</c>; <c>none</c> keeps transparency.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardsmallimagebackcolor">
    /// WizardSmallImageBackColor
    /// </a>.
    /// </summary>
    public SetupBuilder WizardSmallImageBackColor(IssColor value) => SetPropertyValue(value);

    /// <summary>
    /// Overrides <c>WizardSmallImageBackColor</c> when <c>WizardStyle</c> uses the <c>dynamic</c> mode and Windows
    /// is in dark mode. Added in Inno Setup 6.6.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardsmallimagebackcolordynamicdark">
    /// WizardSmallImageBackColorDynamicDark
    /// </a>.
    /// </summary>
    public SetupBuilder WizardSmallImageBackColorDynamicDark(IssColor value) => SetPropertyValue(value);

    /// <summary>
    /// Overrides <c>WizardSmallImageFile</c> when <c>WizardStyle</c> uses the <c>dynamic</c> mode and Windows is in
    /// dark mode. Added in Inno Setup 6.6.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardsmallimagefiledynamicdark">
    /// WizardSmallImageFileDynamicDark
    /// </a>.
    /// </summary>
    public SetupBuilder WizardSmallImageFileDynamicDark(string value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies the visual style and appearance of Setup and Uninstall; combine the
    /// <see cref="WizardStyle"/> members with <c>|</c>.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardstyle">WizardStyle</a>.
    /// </summary>
    public SetupBuilder WizardStyle(WizardStyle value) => SetPropertyValue(value);

    /// <summary>
    /// Specifies a custom VCL Styles file (<c>.vsf</c>) to be used as the default style, or one of
    /// <c>builtin:polar</c>, <c>builtin:slate</c>, <c>builtin:stellar</c> and <c>builtin:zircon</c>.
    /// Added in Inno Setup 6.6.
    /// See <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardstylefile">WizardStyleFile</a>.
    /// </summary>
    public SetupBuilder WizardStyleFile(string value) => SetPropertyValue(value);

    /// <summary>
    /// Overrides <c>WizardStyleFile</c> when <c>WizardStyle</c> uses the <c>dynamic</c> mode and Windows is in
    /// dark mode. Added in Inno Setup 6.6.
    /// See
    /// <a href="https://jrsoftware.org/inno-setup/documentation/?topic=setup_wizardstylefiledynamicdark">
    /// WizardStyleFileDynamicDark
    /// </a>.
    /// </summary>
    public SetupBuilder WizardStyleFileDynamicDark(string value) => SetPropertyValue(value);

    private SetupBuilder AppName(string value) => SetPropertyValue(value);
}