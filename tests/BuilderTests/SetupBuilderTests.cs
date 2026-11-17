namespace BuilderTests;

using System.IO;
using System.Linq;

public class SetupBuilderTests
{
    private static string GetValue(Action<SetupBuilder> configure, string key)
    {
        var builder = new SetupBuilder();
        configure(builder.Create("App"));

        var writer = new StringWriter();
        builder.Write(writer);

        return writer.ToString()
            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Single(x => x.StartsWith($"{key}="))
            .Substring(key.Length + 1);
    }

    [Fact]
    public void ArchiveExtractionValuesMatchDocumentation()
    {
        ArchiveExtraction.Auto.GetString().Should().Be("auto");
        ArchiveExtraction.Basic.GetString().Should().Be("basic");
        ArchiveExtraction.EnhancedNoPassword.GetString().Should().Be("enhanced/nopassword");
        ArchiveExtraction.Enhanced.GetString().Should().Be("enhanced");
        ArchiveExtraction.Full.GetString().Should().Be("full");
    }

    [Fact]
    public void DiskSliceSizeAccepts64BitSizes()
    {
        GetValue(x => x.DiskSliceSize(9223372036800000000), "DiskSliceSize").Should().Be("9223372036800000000");
    }

    [Fact]
    public void EncryptionKeyDerivationWithIterationsOutsideRangeThrows()
    {
        Action zero = () => new SetupBuilder().Create("App").EncryptionKeyDerivation(0);
        zero.Should().Throw<ArgumentOutOfRangeException>();

        Action negative = () => new SetupBuilder().Create("App").EncryptionKeyDerivation(-1);
        negative.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void EncryptionKeyDerivationWithIterationsWritesPbkdf2WithCount()
    {
        GetValue(x => x.EncryptionKeyDerivation(1), "EncryptionKeyDerivation").Should().Be("pbkdf2/1");

        GetValue(x => x.EncryptionKeyDerivation(1_000_000), "EncryptionKeyDerivation")
            .Should().Be("pbkdf2/1000000");

        GetValue(x => x.EncryptionKeyDerivation(int.MaxValue), "EncryptionKeyDerivation")
            .Should().Be("pbkdf2/2147483647");
    }

    [Fact]
    public void EncryptionKeyDerivationWithoutIterationsWritesPbkdf2()
    {
        GetValue(x => x.EncryptionKeyDerivation(), "EncryptionKeyDerivation").Should().Be("pbkdf2");
    }

    [Fact]
    public void EncryptionModeValuesMatchDocumentation()
    {
        EncryptionMode.No.GetString().Should().Be("no");
        EncryptionMode.Yes.GetString().Should().Be("yes");
        EncryptionMode.Full.GetString().Should().Be("full");
    }

    [Fact]
    public void PrecompiledFileVerificationsIsWritableAsFlags()
    {
        (PrecompiledFileVerifications.Setup | PrecompiledFileVerifications.Is7z).GetString()
            .Should().Be("setup is7z");

        (PrecompiledFileVerifications.SetupLdr |
         PrecompiledFileVerifications.IsBunzip |
         PrecompiledFileVerifications.IsUnzlib |
         PrecompiledFileVerifications.IsLzma).GetString()
            .Should().Be("setupldr isbunzip isunzlib islzma");

        PrecompiledFileVerifications.SetupCustomStyle.GetString().Should().Be("setupcustomstyle");
    }

    [Fact]
    public void ScriptedBooleansAcceptYesNoValues()
    {
        GetValue(x => x.Uninstallable(YesNo.Yes), "Uninstallable").Should().Be("yes");
        GetValue(x => x.ChangesAssociations(YesNo.No), "ChangesAssociations").Should().Be("no");
        GetValue(x => x.CreateUninstallRegKey(YesNo.Auto), "CreateUninstallRegKey").Should().Be("auto");
        GetValue(x => x.UsePreviousTasks(YesNo.Yes), "UsePreviousTasks").Should().Be("yes");
    }

    [Fact]
    public void ScriptedBooleansAreWrittenWithoutQuotes()
    {
        var scripted = new (Action<SetupBuilder> Configure, string Key, string Value)[]
        {
            (x => x.Uninstallable("{code:IsX}"), "Uninstallable", "{code:IsX}"),
            (x => x.ChangesAssociations("{code:IsX}"), "ChangesAssociations", "{code:IsX}"),
            (x => x.ChangesEnvironment("{code:IsX}"), "ChangesEnvironment", "{code:IsX}"),
            (x => x.UsePreviousAppDir("{code:IsX}"), "UsePreviousAppDir", "{code:IsX}"),
            (x => x.UsePreviousGroup("{code:IsX}"), "UsePreviousGroup", "{code:IsX}"),
            (x => x.UsePreviousSetupType("{code:IsX}"), "UsePreviousSetupType", "{code:IsX}"),
            (x => x.UsePreviousTasks("{code:IsX}"), "UsePreviousTasks", "{code:IsX}"),
            (x => x.UsePreviousUserInfo("{code:IsX}"), "UsePreviousUserInfo", "{code:IsX}"),
            (
                x => x.CreateUninstallRegKey("not IsTaskSelected('portablemode')"),
                "CreateUninstallRegKey",
                "not IsTaskSelected('portablemode')")
        };

        foreach (var (configure, key, value) in scripted)
            GetValue(configure, key).Should().Be(value);
    }

    [Fact]
    public void SetupArchitectureValuesMatchDocumentation()
    {
        SetupArchitecture.X86.GetString().Should().Be("x86");
        SetupArchitecture.X64.GetString().Should().Be("x64");

        GetValue(x => x.SetupArchitecture(SetupArchitecture.X64), "SetupArchitecture").Should().Be("x64");
    }

    [Fact]
    public void SetupLdrModeValuesMatchDocumentation()
    {
        SetupLdrMode.No.GetString().Should().Be("no");
        SetupLdrMode.Yes.GetString().Should().Be("yes");
        SetupLdrMode.X86.GetString().Should().Be("x86");
        SetupLdrMode.X64.GetString().Should().Be("x64");

        GetValue(x => x.UseSetupLdr(SetupLdrMode.X64), "UseSetupLdr").Should().Be("x64");
    }

    [Fact]
    public void WizardColorsAreWrittenWithoutQuotes()
    {
        GetValue(x => x.WizardBackColor(17), "WizardBackColor").Should().Be("$000011");
        GetValue(x => x.WizardBackColorDynamicDark("#fff"), "WizardBackColorDynamicDark").Should().Be("#fff");
        GetValue(x => x.WizardImageBackColor(IssColor.Named("cornflowerblue")), "WizardImageBackColor")
            .Should().Be("cornflowerblue");
        GetValue(x => x.WizardSmallImageBackColor(IssColor.None), "WizardSmallImageBackColor").Should().Be("none");
    }

    [Fact]
    public void WizardStyleIsWritableAsFlags()
    {
        (WizardStyle.Modern | WizardStyle.Dark | WizardStyle.Dynamic).GetString()
            .Should().Be("modern dark dynamic");

        (WizardStyle.Classic | WizardStyle.Light | WizardStyle.Polar | WizardStyle.IncludeTitleBar).GetString()
            .Should().Be("classic light polar includetitlebar");

        (WizardStyle.Windows11 | WizardStyle.ExcludeLightButtons | WizardStyle.HideBevels).GetString()
            .Should().Be("windows11 excludelightbuttons hidebevels");

        WizardStyle.Slate.GetString().Should().Be("slate");
        WizardStyle.Stellar.GetString().Should().Be("stellar");
        WizardStyle.Zircon.GetString().Should().Be("zircon");
    }
}