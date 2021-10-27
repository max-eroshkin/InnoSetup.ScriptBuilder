namespace InnoSetup.ScriptBuilder.Model.SetupSection
{
    using FileSection;

    public class SetupSection : ModelBase
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

        public string Uninstallable { get; set; }

        public string CloseApplicationsFilter { get; set; }

        public string SetupMutex { get; set; }

        public string ChangesEnvironment { get; set; }

        public string ChangesAssociations { get; set; }

        public string InfoBeforeText { get; set; }

        public string LicenseText { get; set; }

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

        public PrivilegesRequired? PrivilegesRequired { get; set; }

        public SetupPrivilegesRequiredOverrides? PrivilegesRequiredOverridesAllowed { get; set; }

        public SetupOption? Options { get; set; }

        public string OutputDir { get; set; }

        public string OutputBaseFilename { get; set; }

        public string OutputManifestFile { get; set; }

        public string SetupIconFile { get; set; }

        // public string AllowCancelDuringInstall { get; set; }
        // public string AllowNetworkDrive { get; set; }
        // public string AllowNoIcons { get; set; }
        // public string AllowRootDirectory { get; set; }
        // public string AllowUNCPath { get; set; }
        // public string AlwaysRestart { get; set; }
        // public string AlwaysShowComponentsList { get; set; }
        // public string AlwaysShowDirOnReadyPage { get; set; }
        // public string AlwaysShowGroupOnReadyPage { get; set; }
        // public string AlwaysUsePersonalGroup { get; set; }
        // public string AppendDefaultDirName { get; set; }
        // public string AppendDefaultGroupName { get; set; }
        // public string ArchitecturesAllowed { get; set; }
        // public string ArchitecturesInstallIn64BitMode { get; set; }
        // public string ASLRCompatible { get; set; }
        // public string BackColorDirection { get; set; }
        // public string BackSolid { get; set; }
        // public string CloseApplications { get; set; }
        // public string Compression { get; set; }
        // public string CompressionThreads { get; set; }
        // public string CreateAppDir { get; set; }
        // public string DefaultDialogFontName { get; set; }
        // public string DEPCompatible { get; set; }
        // public string DisableFinishedPage { get; set; }
        // public string DisableReadyMemo { get; set; }
        // public string DisableReadyPage { get; set; }
        // public string DisableStartupPrompt { get; set; }
        // public string DisableWelcomePage { get; set; }
        // public string DiskClusterSize { get; set; }
        // public string DiskSliceSize { get; set; }
        // public string DiskSpanning { get; set; }
        // public string DontMergeDuplicateFiles { get; set; }
        // public string EnableDirDoesntExistWarning { get; set; }
        // public string Encryption { get; set; }
        // public string FlatComponentsList { get; set; }
        // public string InfoAfterFile { get; set; }
        // public string InfoBeforeFile { get; set; }
        // public string InternalCompressLevel { get; set; }
        // public string LanguageDetectionMethod { get; set; }
        // public string LicenseFile { get; set; }
        // public string LZMAAlgorithm { get; set; }
        // public string LZMABlockSize { get; set; }
        // public string LZMADictionarySize { get; set; }
        // public string LZMAMatchFinder { get; set; }
        // public string LZMANumBlockThreads { get; set; }
        // public string LZMANumFastBytes { get; set; }
        // public string LZMAUseSeparateProcess { get; set; }
        // public string MergeDuplicateFiles { get; set; }
        // public string MessagesFile { get; set; }
        // public string MinVersion { get; set; }
        // public string MissingMessagesWarning { get; set; }
        // public string MissingRunOnceIdsWarning { get; set; }
        // public string NotRecognizedMessagesWarning { get; set; }
        // public string OnlyBelowVersion { get; set; }
        // public string Output { get; set; }
        // public string Password { get; set; }
        // public string PrivilegesRequired { get; set; }
        // public string ReserveBytes { get; set; }
        // public string RestartApplications { get; set; }
        // public string RestartIfNeededByRun { get; set; }
        // public string SetupLogging { get; set; }
        // public string ShowComponentSizes { get; set; }
        // public string ShowTasksTreeLines { get; set; }
        // public string ShowUndisplayableLanguages { get; set; }
        // public string SignedUninstaller { get; set; }
        // public string SignedUninstallerDir { get; set; }
        // public string SignTool { get; set; }
        // public string SignToolMinimumTimeBetween { get; set; }
        // public string SignToolRetryCount { get; set; }
        // public string SignToolRetryDelay { get; set; }
        // public string SignToolRunMinimized { get; set; }
        // public string SolidCompression { get; set; }
        // public string SourceDir { get; set; }
        // public string TerminalServicesAware { get; set; }
        // public string TimeStampRounding { get; set; }
        // public string TimeStampsInUTC { get; set; }
        // public string TouchDate { get; set; }
        // public string TouchTime { get; set; }
        // public string UpdateUninstallLogAppName { get; set; }
        // public string UninstallIconFile { get; set; }
        // public string UninstallRestartComputer { get; set; }
        // public string UninstallStyle { get; set; }
        // public string UsedUserAreasWarning { get; set; }
        // public string UsePreviousAppDir { get; set; }
        // public string UsePreviousGroup { get; set; }
        // public string UsePreviousLanguage { get; set; }
        // public string UsePreviousPrivileges { get; set; }
        // public string UsePreviousSetupType { get; set; }
        // public string UsePreviousTasks { get; set; }
        // public string UsePreviousUserInfo { get; set; }
        // public string UseSetupLdr { get; set; }
        // public string UserInfoPage { get; set; }
        // public string VersionInfoCompany { get; set; }
        // public string VersionInfoCopyright { get; set; }
        // public string VersionInfoDescription { get; set; }
        // public string VersionInfoOriginalFileName { get; set; }
        // public string VersionInfoProductName { get; set; }
        // public string VersionInfoProductVersion { get; set; }
        // public string VersionInfoProductTextVersion { get; set; }
        // public string VersionInfoTextVersion { get; set; }
        // public string VersionInfoVersion { get; set; }
        // public string WindowResizable { get; set; }
        // public string WindowShowCaption { get; set; }
        // public string WindowStartMaximized { get; set; }
        // public string WindowVisible { get; set; }
        // public string WizardImageBackColor { get; set; }
        // public string WizardImageFile { get; set; }
        // public string WizardImageStretch { get; set; }
        // public string WizardResizable { get; set; }
        // public string WizardSmallImageBackColor { get; set; }
        // public string WizardSmallImageFile { get; set; }
        // public string WizardSizePercent { get; set; }
        // public string WizardStyle { get; set; }
    }
}