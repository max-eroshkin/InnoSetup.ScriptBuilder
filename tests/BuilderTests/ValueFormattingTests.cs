namespace BuilderTests
{
    using System.Linq;
    using System.Reflection;

    public class ValueFormattingTests
    {
        [Flags]
        private enum TestEnum
        {
            Plain = 1,

            [IssValue("enhanced/nopassword")] EnhancedNoPassword = 1 << 1,

            [IssValue("pbkdf2/220000")] Pbkdf2Default = 1 << 2,

            WithUnderscore = 1 << 3
        }

        [Fact]
        public void EnumValuesAreLowercased()
        {
            (Permissions.ReadExec | Permissions.Modify).GetString().Should().Be("readexec modify");
            Sids.AuthUsers.GetString().Should().Be("authusers");
            RegistryKeys.HKLM.GetString().Should().Be("hklm");
            DeleteTypes.FilesAndOrDirs.GetString().Should().Be("filesandordirs");
        }

        [Fact]
        public void FlagsCombinationRemovesUnderscores()
        {
            (FileFlags.Sign | FileFlags._32bit).GetString().Should().Be("32bit sign");
        }

        [Fact]
        public void IssColorFromLiteral()
        {
            IssColor hex = "#fff";
            hex.Value.Should().Be("#fff");

            IssColor red = "#ff0000";
            red.Value.Should().Be("#ff0000");

            IssColor named = "cornflowerblue";
            named.Value.Should().Be("cornflowerblue");

            IssColor.None.Value.Should().Be("none");
            IssColor.Window.Value.Should().Be("window");
            IssColor.White.Value.Should().Be("white");
            IssColor.None.ToString().Should().Be("none");
            ((object)IssColor.None).GetString().Should().Be("none");
        }

        [Fact]
        public void IssColorFromTColorInteger()
        {
            IssColor color = 255L;

            color.Value.Should().Be("$0000ff");
            color.ToString().Should().Be("$0000ff");
            ((object)color).GetString().Should().Be("$0000ff");

            IssColor intColor = 255;
            intColor.Should().Be(color);

            IssColor pureGreenTColor = 0x00FF00L;
            pureGreenTColor.Value.Should().Be("$00ff00");
        }

        [Fact]
        public void IssColorHexProducesRgbNotation()
        {
            IssColor.Hex(0, 0, 0).Value.Should().Be("#000000");
            IssColor.Hex(255, 255, 255).Value.Should().Be("#ffffff");
            IssColor.Hex(0x11, 0x22, 0x33).Value.Should().Be("#112233");

            Action outOfRange = () => IssColor.Hex(256, 0, 0);
            outOfRange.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void IssValueAttributeIsWrittenVerbatim()
        {
            TestEnum.EnhancedNoPassword.GetString().Should().Be("enhanced/nopassword");
            TestEnum.Pbkdf2Default.GetString().Should().Be("pbkdf2/220000");
            TestEnum.WithUnderscore.GetString().Should().Be("withunderscore");
            TestEnum.Plain.GetString().Should().Be("plain");
        }

        [Fact]
        public void IssValueAttributeWorksInsideFlagsCombination()
        {
            (TestEnum.Plain | TestEnum.EnhancedNoPassword | TestEnum.WithUnderscore).GetString()
                .Should().Be("plain enhanced/nopassword withunderscore");
        }

        [Fact]
        public void IssYesNoFromYesNo()
        {
            IssYesNo yes = YesNo.Yes;

            yes.Value.Should().Be("yes");
            yes.ToString().Should().Be("yes");
            ((object)yes).GetString().Should().Be("yes");
            ((IssYesNo)YesNo.No).Value.Should().Be("no");
            ((IssYesNo)YesNo.Auto).Value.Should().Be("auto");
        }

        [Fact]
        public void IssYesNoKeepsScriptedExpressionUnquoted()
        {
            IssYesNo flag = "{code:IsX}";

            flag.Value.Should().Be("{code:IsX}");
            flag.ToString().Should().Be("{code:IsX}");
            ((object)flag).GetString().Should().Be("{code:IsX}");
        }

        [Fact]
        public void StaticColorNamesMatchMemberNames()
        {
            var colors = typeof(IssColor)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.FieldType == typeof(IssColor))
                .ToList();

            colors.Should().HaveCount(18);
            colors.Should().OnlyContain(x => ((IssColor)x.GetValue(null)).Value == x.Name.ToLower());
        }
    }
}
