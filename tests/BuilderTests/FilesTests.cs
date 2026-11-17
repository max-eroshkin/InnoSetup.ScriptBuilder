namespace BuilderTests;

using System.Collections.Generic;

public class FilesTests : ParameterSectionTestsBase<FileEntry>
{
    protected override string SectionName => "Files";

    protected override Dictionary<string, string> ReferenceData => new()
    {
        { "Source", "\"Source\"" },
        { "DestDir", "\"DestDir\"" },
        { "DestName", "\"DestName\"" },
        { "FontInstall", "\"FontInstall\"" },
        { "Excludes", "\"Excludes\"" },
        { "ExternalSize", "123456" },
        { "StrongAssemblyName", "\"StrongAssemblyName\"" },
        { "ISSigAllowedKeys", "\"exesigner bosskey\"" },
        { "Hash", "\"2f6294f9aa09f59a574b5dcd33be54e16b39377984f3d5658cda44950fa0f8fc\"" },
        { "ExtractArchivePassword", "\"ExtractArchivePassword\"" },
        { "DownloadISSigSource", "\"https://example.com/App.exe.issig\"" },
        { "DownloadUserName", "\"DownloadUserName\"" },
        { "DownloadPassword", "\"DownloadPassword\"" },
        { "Components", "\"Components\"" },
        { "Tasks", "\"Tasks\"" },
        { "Languages", "\"Languages\"" },
        { "MinVersion", "\"MinVersion\"" },
        { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
        { "Permissions", "service-full admins-modify" },
        { "Flags", "external ignoreversion download extractarchive issigverify" },
        { "Attribs", "readonly system" },
        { "Check", "\"Check\"" },
        { "BeforeInstall", "\"BeforeInstall\"" },
        { "AfterInstall", "\"AfterInstall\"" },
    };
}