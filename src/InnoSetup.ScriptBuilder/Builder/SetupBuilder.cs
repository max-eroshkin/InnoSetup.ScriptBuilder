namespace InnoSetup.ScriptBuilder
{
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
        public SetupBuilder CreateUninstallRegKey(string value) => SetPropertyValue(value);
        public SetupBuilder Uninstallable(YesNo value) => SetPropertyValue(value);
        public SetupBuilder CloseApplicationsFilter(string value) => SetPropertyValue(value);
        public SetupBuilder SetupMutex(string value) => SetPropertyValue(value);
        public SetupBuilder ChangesEnvironment(YesNo value) => SetPropertyValue(value);
        public SetupBuilder ChangesAssociations(YesNo value) => SetPropertyValue(value);
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
        public SetupBuilder BackColor(long value) => SetPropertyValue(value);
        public SetupBuilder BackColor2(long value) => SetPropertyValue(value);
        public SetupBuilder DirExistsWarning(YesNo value) => SetPropertyValue(value);
        public SetupBuilder ShowLanguageDialog(YesNo value) => SetPropertyValue(value);
        public SetupBuilder UninstallLogMode(UninstallLogMode value) => SetPropertyValue(value);
        public SetupBuilder WizardImageAlphaFormat(WizardImageAlphaFormat value) => SetPropertyValue(value);
        public SetupBuilder WizardSizePercentX(int value) => SetPropertyValue(value);
        public SetupBuilder WizardSizePercentY(int value) => SetPropertyValue(value);
        public SetupBuilder ExtraDiskSpaceRequired(long value) => SetPropertyValue(value);
        public SetupBuilder SlicesPerDisk(int value) => SetPropertyValue(value);
        public SetupBuilder UninstallDisplaySize(long value) => SetPropertyValue(value);
        public SetupBuilder DisableDirPage(YesNo value) => SetPropertyValue(value);
        public SetupBuilder DisableProgramGroupPage(YesNo value) => SetPropertyValue(value);
        public SetupBuilder DisableWelcomePage(YesNo value) => SetPropertyValue(value);
        public SetupBuilder PrivilegesRequired(PrivilegesRequired value) => SetPropertyValue(value);

        public SetupBuilder PrivilegesRequiredOverridesAllowed(SetupPrivilegesRequiredOverrides value) =>
            SetPropertyValue(value);

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

        public SetupBuilder AlwaysRestart(YesNo value) => SetPropertyValue(value);

        public SetupBuilder AlwaysShowComponentsList(YesNo value) => SetPropertyValue(value);

        public SetupBuilder AlwaysShowDirOnReadyPage(YesNo value) => SetPropertyValue(value);

        public SetupBuilder AlwaysShowGroupOnReadyPage(YesNo value) => SetPropertyValue(value);

        public SetupBuilder AlwaysUsePersonalGroup(YesNo value) => SetPropertyValue(value);

        public SetupBuilder AppendDefaultDirName(YesNo value) => SetPropertyValue(value);

        public SetupBuilder AppendDefaultGroupName(YesNo value) => SetPropertyValue(value);

        public SetupBuilder ArchitecturesAllowed(Architectures value) => SetPropertyValue(value);

        public SetupBuilder ArchitecturesInstallIn64BitMode(ArchitecturesInstallIn64BitMode value) => SetPropertyValue(value);

        public SetupBuilder ASLRCompatible(YesNo value) => SetPropertyValue(value);

        public SetupBuilder BackColorDirection(BackColorDirection value) => SetPropertyValue(value);

        public SetupBuilder BackSolid(YesNo value) => SetPropertyValue(value);

        public SetupBuilder CloseApplications(CloseApplications value) => SetPropertyValue(value);

        public SetupBuilder Compression(string value) => SetPropertyValue(value);

        public SetupBuilder CompressionThreads(uint value) => SetPropertyValue(value);

        public SetupBuilder CreateAppDir(YesNo value) => SetPropertyValue(value);

        public SetupBuilder DefaultDialogFontName(string value) => SetPropertyValue(value);

        public SetupBuilder DEPCompatible(YesNo value) => SetPropertyValue(value);

        public SetupBuilder DisableFinishedPage(YesNo value) => SetPropertyValue(value);

        public SetupBuilder DisableReadyMemo(YesNo value) => SetPropertyValue(value);

        public SetupBuilder DisableReadyPage(YesNo value) => SetPropertyValue(value);

        public SetupBuilder DisableStartupPrompt(YesNo value) => SetPropertyValue(value);

        public SetupBuilder DiskClusterSize(uint value) => SetPropertyValue(value);

        public SetupBuilder DiskSliceSize(uint value) => SetPropertyValue(value);

        public SetupBuilder DiskSpanning(YesNo value) => SetPropertyValue(value);

        public SetupBuilder EnableDirDoesntExistWarning(YesNo value) => SetPropertyValue(value);

        public SetupBuilder Encryption(YesNo value) => SetPropertyValue(value);

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

        public SetupBuilder MinVersion(string value) => SetPropertyValue(value);

        public SetupBuilder MissingMessagesWarning(YesNo value) => SetPropertyValue(value);

        public SetupBuilder MissingRunOnceIdsWarning(YesNo value) => SetPropertyValue(value);

        public SetupBuilder NotRecognizedMessagesWarning(YesNo value) => SetPropertyValue(value);

        public SetupBuilder OnlyBelowVersion(string value) => SetPropertyValue(value);

        public SetupBuilder Output(YesNo value) => SetPropertyValue(value);

        public SetupBuilder Password(string value) => SetPropertyValue(value);

        public SetupBuilder ReserveBytes(uint value) => SetPropertyValue(value);

        public SetupBuilder RestartApplications(YesNo value) => SetPropertyValue(value);

        public SetupBuilder RestartIfNeededByRun(YesNo value) => SetPropertyValue(value);

        public SetupBuilder SetupLogging(YesNo value) => SetPropertyValue(value);

        public SetupBuilder ShowComponentSizes(YesNo value) => SetPropertyValue(value);

        public SetupBuilder ShowTasksTreeLines(YesNo value) => SetPropertyValue(value);

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

        public SetupBuilder UsedUserAreasWarning(YesNo value) => SetPropertyValue(value);

        public SetupBuilder UsePreviousAppDir(YesNo value) => SetPropertyValue(value);

        public SetupBuilder UsePreviousGroup(YesNo value) => SetPropertyValue(value);

        public SetupBuilder UsePreviousLanguage(YesNo value) => SetPropertyValue(value);

        public SetupBuilder UsePreviousPrivileges(YesNo value) => SetPropertyValue(value);

        public SetupBuilder UsePreviousSetupType(YesNo value) => SetPropertyValue(value);

        public SetupBuilder UsePreviousTasks(YesNo value) => SetPropertyValue(value);

        public SetupBuilder UsePreviousUserInfo(YesNo value) => SetPropertyValue(value);

        public SetupBuilder UseSetupLdr(YesNo value) => SetPropertyValue(value);

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

        public SetupBuilder WindowResizable(YesNo value) => SetPropertyValue(value);

        public SetupBuilder WindowShowCaption(YesNo value) => SetPropertyValue(value);

        public SetupBuilder WindowStartMaximized(YesNo value) => SetPropertyValue(value);

        public SetupBuilder WindowVisible(YesNo value) => SetPropertyValue(value);

        public SetupBuilder WizardImageStretch(YesNo value) => SetPropertyValue(value);

        public SetupBuilder WizardResizable(YesNo value) => SetPropertyValue(value);

        public SetupBuilder WizardSizePercent(string value) => SetPropertyValue(value);

        public SetupBuilder WizardStyle(WizardStyle value) => SetPropertyValue(value);

        private SetupBuilder AppName(string value) => SetPropertyValue(value);
    }
}