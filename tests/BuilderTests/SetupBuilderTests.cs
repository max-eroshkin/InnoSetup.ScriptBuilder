namespace BuilderTests;

using System.IO;
using System.Linq;

public class SetupBuilderTests
{
    [Fact]
    public void EncryptionKeyDerivationWithoutIterationsWritesPbkdf2()
    {
        GetValue(x => x.EncryptionKeyDerivation(), "EncryptionKeyDerivation").Should().Be("pbkdf2");
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
    public void EncryptionKeyDerivationWithIterationsOutsideRangeThrows()
    {
        Action zero = () => new SetupBuilder().Create("App").EncryptionKeyDerivation(0);
        zero.Should().Throw<ArgumentOutOfRangeException>();

        Action negative = () => new SetupBuilder().Create("App").EncryptionKeyDerivation(-1);
        negative.Should().Throw<ArgumentOutOfRangeException>();
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

    [Fact]
    public void WizardColorsAreWrittenWithoutQuotes()
    {
        GetValue(x => x.WizardBackColor(17), "WizardBackColor").Should().Be("$000011");
        GetValue(x => x.WizardBackColorDynamicDark("#fff"), "WizardBackColorDynamicDark").Should().Be("#fff");
        GetValue(x => x.WizardImageBackColor(IssColor.Named("cornflowerblue")), "WizardImageBackColor")
            .Should().Be("cornflowerblue");
        GetValue(x => x.WizardSmallImageBackColor(IssColor.None), "WizardSmallImageBackColor").Should().Be("none");
    }

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
}
