namespace BuilderTests
{
    using System;
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
            iss.Should().Be(
                Environment.NewLine + "[Code]" + Environment.NewLine + "code1" + Environment.NewLine +
                            "code2" + Environment.NewLine);
        }
    }
}