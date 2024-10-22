namespace BuilderTests
{
    using System.Collections.Generic;
    using InnoSetup.ScriptBuilder;

    public class SetupTests : KeyValueSectionTestsBase<SetupSection>
    {
        protected override string SectionName => "Setup";

        protected override Dictionary<string, string> ReferenceData => new()
        {
            { "AppName", "BimTools.Support" },
            { "AppVersion", "1.2.5.1634640046" },
            { "DefaultDirName", @"{userappdata}\Autodesk\Revit\Addins\2019\SupportTools" },
            { "PrivilegesRequired", "lowest" },
            { "OutputBaseFilename", "BimTools.Support_2021_1.2.5.1634640046" },
            { "SetupIconFile", "trayIcon.ico" },
            { "UninstallDisplayIcon", "trayIcon.ico" },
            { "DisableDirPage", "yes" },
            { "AppVerName", "AppVerName" },
            { "AppId", "AppId" },
            { "AppCopyright", "AppCopyright" },
            { "AppPublisher", "AppPublisher" },
            { "AppPublisherURL", "AppPublisherURL" },
            { "AppSupportPhone", "AppSupportPhone" },
            { "AppSupportURL", "AppSupportURL" },
            { "AppUpdatesURL", "AppUpdatesURL" },
            { "DefaultGroupName", "DefaultGroupName" },
            { "BaseFilename", "BaseFilename" },
            { "UninstallFilesDir", "UninstallFilesDir" },
            { "UninstallDisplayName", "UninstallDisplayName" },
            { "AppMutex", "AppMutex" },
            { "DefaultUserInfoName", "DefaultUserInfoName" },
            { "DefaultUserInfoOrg", "DefaultUserInfoOrg" },
            { "DefaultUserInfoSerial", "DefaultUserInfoSerial" },
            { "AppReadmeFile", "AppReadmeFile" },
            { "AppContact", "AppContact" },
            { "AppComments", "AppComments" },
            { "AppModifyPath", "AppModifyPath" },
            { "CreateUninstallRegKey", "CreateUninstallRegKey" },
            { "Uninstallable", "yes" },
            { "CloseApplicationsFilter", "CloseApplicationsFilter" },
            { "SetupMutex", "SetupMutex" },
            { "ChangesEnvironment", "yes" },
            { "ChangesAssociations", "yes" },
            { "InfoBeforeText", "InfoBeforeText" },
            { "LicenseText", "LicenseText" },
            { "LicenseFile", "LicenseFile" },
            { "InfoAfterText", "InfoAfterText" },
            { "CompiledCodeText", "CompiledCodeText" },
            { "NumLanguageEntries", "1" },
            { "NumCustomMessageEntries", "2" },
            { "NumPermissionEntries", "3" },
            { "NumTypeEntries", "4" },
            { "NumComponentEntries", "5" },
            { "NumTaskEntries", "6" },
            { "NumDirEntries", "7" },
            { "NumFileEntries", "8" },
            { "NumFileLocationEntries", "9" },
            { "NumIconEntries", "10" },
            { "NumIniEntries", "11" },
            { "NumRegistryEntries", "12" },
            { "NumInstallDeleteEntries", "13" },
            { "NumUninstallDeleteEntries", "14" },
            { "NumRunEntries", "15" },
            { "NumUninstallRunEntries", "16" },
            { "BackColor", "17" },
            { "BackColor2", "17" },
            { "DirExistsWarning", "yes" },
            { "ShowLanguageDialog", "yes" },
            { "UninstallLogMode", "overwrite" },
            { "WizardImageAlphaFormat", "premultiplied" },
            { "WizardSizePercentX", "19" },
            { "WizardSizePercentY", "20" },
            { "ExtraDiskSpaceRequired", "21" },
            { "SlicesPerDisk", "22" },
            { "UninstallDisplaySize", "23" },
            { "DisableProgramGroupPage", "yes" },
            { "DisableWelcomePage", "yes" },
            { "PrivilegesRequiredOverridesAllowed", "commandline" },
            { "Options", "signeduninstaller" },
            { "OutputDir", "OutputDir" },
            { "OutputManifestFile", "OutputManifestFile" },
            { "WizardImageFile", "WizardImageFile" },
            { "WizardSmallImageFile", "WizardSmallImageFile" },
            { "AllowCancelDuringInstall", "yes" },
            { "AllowNetworkDrive", "yes" },
            { "AllowNoIcons", "yes" },
            { "AllowRootDirectory", "yes" },
            { "AllowUNCPath", "yes" },
            { "AlwaysRestart", "yes" },
            { "AlwaysShowComponentsList", "yes" },
            { "AlwaysShowDirOnReadyPage", "yes" },
            { "AlwaysShowGroupOnReadyPage", "yes" },
            { "AlwaysUsePersonalGroup", "yes" },
            { "AppendDefaultDirName", "yes" },
            { "AppendDefaultGroupName", "yes" },
            { "ArchitecturesAllowed", "x86os" },
            { "ArchitecturesInstallIn64BitMode", "arm64" },
            { "ASLRCompatible", "yes" },
            { "BackColorDirection", "toptobottom" },
            { "BackSolid", "yes" },
            { "CloseApplications", "force" },
            { "Compression", "Compression" },
            { "CompressionThreads", "24" },
            { "CreateAppDir", "yes" },
            { "DefaultDialogFontName", "DefaultDialogFontName" },
            { "DEPCompatible", "yes" },
            { "DisableFinishedPage", "yes" },
            { "DisableReadyMemo", "yes" },
            { "DisableReadyPage", "yes" },
            { "DisableStartupPrompt", "yes" },
            { "DiskClusterSize", "25" },
            { "DiskSliceSize", "26" },
            { "DiskSpanning", "yes" },
            { "EnableDirDoesntExistWarning", "yes" },
            { "Encryption", "yes" },
            { "FlatComponentsList", "yes" },
            { "InfoAfterFile", "InfoAfterFile" },
            { "InfoBeforeFile", "InfoBeforeFile" },
            { "InternalCompressLevel", "InternalCompressLevel" },
            { "LanguageDetectionMethod", "locale" },
            { "LZMAAlgorithm", "27" },
            { "LZMABlockSize", "28" },
            { "LZMADictionarySize", "29" },
            { "LZMAMatchFinder", "hc" },
            { "LZMANumBlockThreads", "30" },
            { "LZMANumFastBytes", "31" },
            { "LZMAUseSeparateProcess", "yes" },
            { "MergeDuplicateFiles", "yes" },
            { "MinVersion", "MinVersion" },
            { "MissingMessagesWarning", "yes" },
            { "MissingRunOnceIdsWarning", "yes" },
            { "NotRecognizedMessagesWarning", "yes" },
            { "OnlyBelowVersion", "OnlyBelowVersion" },
            { "Output", "yes" },
            { "Password", "Password" },
            { "ReserveBytes", "32" },
            { "RestartApplications", "yes" },
            { "RestartIfNeededByRun", "yes" },
            { "SetupLogging", "yes" },
            { "ShowComponentSizes", "yes" },
            { "ShowTasksTreeLines", "yes" },
            { "ShowUndisplayableLanguages", "yes" },
            { "SignedUninstaller", "yes" },
            { "SignedUninstallerDir", "SignedUninstallerDir" },
            { "SignTool", "SignTool" },
            { "SignToolMinimumTimeBetween", "33" },
            { "SignToolRetryCount", "34" },
            { "SignToolRetryDelay", "35" },
            { "SignToolRunMinimized", "yes" },
            { "SolidCompression", "yes" },
            { "SourceDir", "SourceDir" },
            { "TerminalServicesAware", "yes" },
            { "TimeStampRounding", "36" },
            { "TimeStampsInUTC", "yes" },
            { "TouchDate", "TouchDate" },
            { "TouchTime", "TouchTime" },
            { "UpdateUninstallLogAppName", "yes" },
            { "UninstallLogging", "yes" },
            { "UninstallRestartComputer", "yes" },
            { "UsedUserAreasWarning", "yes" },
            { "UsePreviousAppDir", "yes" },
            { "UsePreviousGroup", "yes" },
            { "UsePreviousLanguage", "yes" },
            { "UsePreviousPrivileges", "yes" },
            { "UsePreviousSetupType", "yes" },
            { "UsePreviousTasks", "yes" },
            { "UsePreviousUserInfo", "yes" },
            { "UseSetupLdr", "yes" },
            { "UserInfoPage", "yes" },
            { "VersionInfoCompany", "VersionInfoCompany" },
            { "VersionInfoCopyright", "VersionInfoCopyright" },
            { "VersionInfoDescription", "VersionInfoDescription" },
            { "VersionInfoOriginalFileName", "VersionInfoOriginalFileName" },
            { "VersionInfoProductName", "VersionInfoProductName" },
            { "VersionInfoProductVersion", "VersionInfoProductVersion" },
            { "VersionInfoProductTextVersion", "VersionInfoProductTextVersion" },
            { "VersionInfoTextVersion", "VersionInfoTextVersion" },
            { "VersionInfoVersion", "VersionInfoVersion" },
            { "WindowResizable", "yes" },
            { "WindowShowCaption", "yes" },
            { "WindowStartMaximized", "yes" },
            { "WindowVisible", "yes" },
            { "WizardImageStretch", "yes" },
            { "WizardResizable", "yes" },
            { "WizardSizePercent", "WizardSizePercent" },
            { "WizardStyle", "modern" },
        };
    }
}