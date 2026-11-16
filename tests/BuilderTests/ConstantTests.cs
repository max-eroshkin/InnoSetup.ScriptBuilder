namespace BuilderTests
{
    using System.Linq;
    using System.Reflection;

    public class ConstantTests
    {
        [Fact]
        public void AutoConstants()
        {
            InnoConstants.Auto.AppData.Should().Be(@"{autoappdata}");
            InnoConstants.Auto.CommonFiles.Should().Be(@"{autocf}");
            InnoConstants.Auto.CommonFiles32.Should().Be(@"{autocf32}");
            InnoConstants.Auto.CommonFiles64.Should().Be(@"{autocf64}");
            InnoConstants.Auto.Desktop.Should().Be(@"{autodesktop}");
            InnoConstants.Auto.Docs.Should().Be(@"{autodocs}");
            InnoConstants.Auto.Fonts.Should().Be(@"{autofonts}");
            InnoConstants.Auto.ProgramFiles.Should().Be(@"{autopf}");
            InnoConstants.Auto.ProgramFiles32.Should().Be(@"{autopf32}");
            InnoConstants.Auto.ProgramFiles64.Should().Be(@"{autopf64}");
            InnoConstants.Auto.Programs.Should().Be(@"{autoprograms}");
            InnoConstants.Auto.StartMenu.Should().Be(@"{autostartmenu}");
            InnoConstants.Auto.Startup.Should().Be(@"{autostartup}");
            InnoConstants.Auto.Templates.Should().Be(@"{autotemplates}");
        }

        [Fact]
        public void AutoConstantsAreComplete()
        {
            var values = typeof(InnoConstants.Auto)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(f => (string)f.GetRawConstantValue())
                .ToArray();

            values.Should().OnlyHaveUniqueItems().And.HaveCount(14);
            values.Should().OnlyContain(v => v.StartsWith("{auto") && v.EndsWith("}"));
        }

        [Fact]
        public void GetCodeResult()
        {
            InnoConstants.Inno.GetCodeResult(@"function")
                .Should().Be(@"{code:function}");
        }

        [Fact]
        public void GetCustomMessage()
        {
            InnoConstants.Inno.GetCustomMessage(@"LaunchProgram", "Inno Setup")
                .Should().Be(@"{cm:LaunchProgram,Inno Setup}");

            InnoConstants.Inno.GetCustomMessage(@"LaunchProgram")
                .Should().Be(@"{cm:LaunchProgram}");
        }

        [Fact]
        public void GetDrive()
        {
            InnoConstants.Inno.GetDrive(@"c:\path\file")
                .Should().Be(@"{drive:c:\path\file}");
        }

        [Fact]
        public void GetEnvironmentVariabfle()
        {
            InnoConstants.Inno.GetCommandLineParameter(@"Path", @"{autopf}\My Program")
                .Should().Be(@"{param:Path|{autopf}\My Program}");

            InnoConstants.Inno.GetCommandLineParameter(@"Path")
                .Should().Be(@"{param:Path}");
        }

        [Fact]
        public void GetEnvironmentVariable()
        {
            InnoConstants.Inno.GetEnvironmentVariable(@"COMSPEC")
                .Should().Be(@"{%COMSPEC}");

            InnoConstants.Inno.GetEnvironmentVariable(@"PROMPT", "$P$G")
                .Should().Be(@"{%PROMPT|$P$G}");
        }

        [Fact]
        public void GetIniVariable()
        {
            InnoConstants.Inno.GetIniVariable(@"{win}\MyProg.ini", "Settings", "Path", @"{autopf}\My Program")
                .Should().Be(@"{ini:{win}\MyProg.ini,Settings,Path|{autopf}\My Program}");

            InnoConstants.Inno.GetIniVariable(@"{win}\MyProg.ini", "Settings", "Path")
                .Should().Be(@"{ini:{win}\MyProg.ini,Settings,Path}");
        }

        [Fact]
        public void GetRegValue()
        {
            InnoConstants.Inno.GetRegValue(RegistryKeys.HKA, @"Software\My Program", "Path", @"{autopf}\My Program")
                .Should().Be(@"{reg:HKA\Software\My Program,Path|{autopf}\My Program}");

            InnoConstants.Inno.GetRegValue(RegistryKeys.HKA, @"Software\My Program", "Path")
                .Should().Be(@"{reg:HKA\Software\My Program,Path}");

            InnoConstants.Inno.GetRegValue(
                    RegistryKeys.HKA,
                    @"Software\My Program",
                    defaultValue: @"{autopf}\My Program")
                .Should().Be(@"{reg:HKA\Software\My Program|{autopf}\My Program}");
        }

        [Fact]
        public void RenamedConstants()
        {
            InnoConstants.Pf.Should().Be(@"{pf}");
            InnoConstants.Pf32.Should().Be(@"{pf32}");
            InnoConstants.Pf64.Should().Be(@"{pf64}");
            InnoConstants.Cf.Should().Be(@"{cf}");
            InnoConstants.Cf32.Should().Be(@"{cf32}");
            InnoConstants.Cf64.Should().Be(@"{cf64}");
            InnoConstants.Fonts.Should().Be(@"{fonts}");
            InnoConstants.SendTo.Should().Be(@"{sendto}");
        }

        [Fact]
        public void RenamedConstantsAreObsolete()
        {
            typeof(InnoConstants)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.IsLiteral && f.FieldType == typeof(string))
                .Should().OnlyContain(f => f.GetCustomAttribute<ObsoleteAttribute>() != null);
        }
    }
}
