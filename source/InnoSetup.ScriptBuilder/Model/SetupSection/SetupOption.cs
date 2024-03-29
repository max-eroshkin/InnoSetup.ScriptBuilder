﻿namespace InnoSetup.ScriptBuilder
{
    using System;

    [Flags]
    public enum SetupOption : ulong
    {
        DisableStartupPrompt = 1,
        CreateAppDir = 1 << 1,
        AllowNoIcons = 1 << 2,
        AlwaysRestart = 1 << 3,
        AlwaysUsePersonalGroup = 1 << 4,
        WindowVisible = 1 << 5,
        WindowShowCaption = 1 << 6,
        WindowResizable = 1 << 7,
        WindowStartMaximized = 1 << 8,
        EnableDirDoesntExistWarning = 1 << 9,
        Password = 1 << 10,
        AllowRootDirectory = 1 << 11,
        DisableFinishedPage = 1 << 12,
        UsePreviousAppDir = 1 << 13,
        BackColorHorizontal = 1 << 14,
        UsePreviousGroup = 1 << 15,
        UpdateUninstallLogAppName = 1 << 16,
        UsePreviousSetupType = 1 << 17,
        DisableReadyMemo = 1 << 18,
        AlwaysShowComponentsList = 1 << 19,
        FlatComponentsList = 1 << 20,
        ShowComponentSizes = 1 << 21,
        UsePreviousTasks = 1 << 22,
        DisableReadyPage = 1 << 23,
        AlwaysShowDirOnReadyPage = 1 << 24,
        AlwaysShowGroupOnReadyPage = 1 << 25,
        AllowUNCPath = 1 << 26,
        UserInfoPage = 1 << 27,
        UsePreviousUserInfo = 1 << 28,
        UninstallRestartComputer = 1 << 29,
        RestartIfNeededByRun = 1 << 30,
        ShowTasksTreeLines = 1ul << 31,
        AllowCancelDuringInstall = 1ul << 32,
        WizardImageStretch = 1ul << 33,
        AppendDefaultDirName = 1ul << 34,
        AppendDefaultGroupName = 1ul << 35,
        EncryptionUsed = 1ul << 36,
        SignedUninstaller = 1ul << 37,
        UsePreviousLanguage = 1ul << 38,
        DisableWelcomePage = 1ul << 39,
        CloseApplications = 1ul << 40,
        RestartApplications = 1ul << 41,
        AllowNetworkDrive = 1ul << 42,
        ForceCloseApplications = 1ul << 43,
        AppNameHasConsts = 1ul << 44,
        UsePreviousPrivileges = 1ul << 45,
        WizardResizable = 1ul << 46,
    }
}