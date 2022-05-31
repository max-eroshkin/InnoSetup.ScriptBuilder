namespace BuilderTests
{
    using FluentAssertions;
    using InnoSetup.ScriptBuilder;
    using Xunit;

    public class ConstantTests
    {
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
            
            InnoConstants.Inno.GetRegValue(RegistryKeys.HKA, @"Software\My Program", defaultValue: @"{autopf}\My Program")
                .Should().Be(@"{reg:HKA\Software\My Program|{autopf}\My Program}");
        }
        
        [Fact]
        public void GetEnvironmentVariabfle()
        {
            InnoConstants.Inno.GetCommandLineParameter(@"Path", @"{autopf}\My Program")
                .Should().Be(@"{param:Path|{autopf}\My Program}");
            
            InnoConstants.Inno.GetCommandLineParameter(@"Path")
                .Should().Be(@"{param:Path}");
        }
    }
}