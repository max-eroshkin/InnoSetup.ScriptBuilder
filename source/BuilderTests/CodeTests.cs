namespace BuilderTests
{
    using FluentAssertions;
    using InnoSetup.ScriptBuilder;
    using Xunit;

    public class CodeTests
    {
        [Fact]
        public void Test()
        {
            var iss = BuilderUtils.CreateBuilder(builder => builder.Code
                    .CreateEntry("code1")
                    .CreateEntry("code2"))
                .ToString();
            iss.Should().Be("\r\n[Code]\r\ncode1\r\ncode2\r\n");
        }
    }
}