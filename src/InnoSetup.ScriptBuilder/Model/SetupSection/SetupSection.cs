namespace InnoSetup.ScriptBuilder
{
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

        public long? BackColor { get; set; }

        public long? BackColor2 { get; set; }

        public YesNo? DirExistsWarning { get; set; }

        public YesNo? ShowLanguageDialog { get; set; }

        public UninstallLogMode? UninstallLogMode { get; set; }

        public WizardImageAlphaFormat? WizardImageAlphaFormat { get; set; }

        public int? WizardSizePercentX { get; set; }

        public int? WizardSizePercentY { get; set; }

        public long? ExtraDiskSpaceRequired { get; set; }

        public int? SlicesPerDisk { get; set; }

        public long? UninstallDisplaySize { get; set; }

        public YesNo? DisableDirPage { get; set; }

        public YesNo? DisableProgramGroupPage { get; set; }

        public YesNo? DisableWelcomePage { get; set; }

        public PrivilegesRequired? PrivilegesRequired { get; set; }

        public SetupPrivilegesRequiredOverrides? PrivilegesRequiredOverridesAllowed { get; set; }

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

        public YesNo? AlwaysRestart { get; set; }

        public YesNo? AlwaysShowComponentsList { get; set; }

        public YesNo? AlwaysShowDirOnReadyPage { get; set; }

        public YesNo? AlwaysShowGroupOnReadyPage { get; set; }

        public YesNo? AlwaysUsePersonalGroup { get; set; }

        public YesNo? AppendDefaultDirName { get; set; }

        public YesNo? AppendDefaultGroupName { get; set; }

        public Architectures? ArchitecturesAllowed { get; set; }

        public ArchitecturesInstallIn64BitMode? ArchitecturesInstallIn64BitMode { get; set; }

        public YesNo? ASLRCompatible { get; set; }

        public BackColorDirection? BackColorDirection { get; set; }

        public YesNo? BackSolid { get; set; }

        public CloseApplications? CloseApplications { get; set; }

        public string Compression { get; set; }

        public uint? CompressionThreads { get; set; }

        public YesNo? CreateAppDir { get; set; }

        public string DefaultDialogFontName { get; set; }

        public YesNo? DEPCompatible { get; set; }

        public YesNo? DisableFinishedPage { get; set; }

        public YesNo? DisableReadyMemo { get; set; }

        public YesNo? DisableReadyPage { get; set; }

        public YesNo? DisableStartupPrompt { get; set; }

        public uint? DiskClusterSize { get; set; }

        public uint? DiskSliceSize { get; set; }

        public YesNo? DiskSpanning { get; set; }

        public YesNo? EnableDirDoesntExistWarning { get; set; }

        public YesNo? Encryption { get; set; }

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

        public string MinVersion { get; set; }

        public YesNo? MissingMessagesWarning { get; set; }

        public YesNo? MissingRunOnceIdsWarning { get; set; }

        public YesNo? NotRecognizedMessagesWarning { get; set; }

        public string OnlyBelowVersion { get; set; }

        public YesNo? Output { get; set; }

        public string Password { get; set; }

        public uint? ReserveBytes { get; set; }

        public YesNo? RestartApplications { get; set; }

        public YesNo? RestartIfNeededByRun { get; set; }

        public YesNo? SetupLogging { get; set; }

        public YesNo? ShowComponentSizes { get; set; }

        public YesNo? ShowTasksTreeLines { get; set; }

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

        public YesNo? WindowResizable { get; set; }

        public YesNo? WindowShowCaption { get; set; }

        public YesNo? WindowStartMaximized { get; set; }

        public YesNo? WindowVisible { get; set; }

        public YesNo? WizardImageStretch { get; set; }

        public YesNo? WizardResizable { get; set; }

        public string WizardSizePercent { get; set; }

        public WizardStyle? WizardStyle { get; set; }
    }
}