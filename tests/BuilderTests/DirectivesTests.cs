namespace BuilderTests;

public class DirectivesTests
{
    [Theory]
    [InlineData("string", "#define var_test \"string\"")]
    [InlineData(1, "#define var_test 1")]
    [InlineData(2U, "#define var_test 2")]
    [InlineData(3L, "#define var_test 3")]
    [InlineData(4UL, "#define var_test 4")]
    [InlineData(DirFlags.DeleteAfterInstall, "#define var_test deleteafterinstall")]
    public void DefineVariable(object value, string definition)
    {
        var scriptBuilder = BuilderUtils.CreateBuilder(x => x.Directives.DefineVariable("var_test", value));
        var result = GetString(scriptBuilder);
        result.Should().Be(definition);
    }

    private string GetString(IssBuilder builder)
    {
        return builder.ToString().TrimEnd('\n').TrimEnd('\r');
    }

    [Fact]
    public void Define()
    {
        var scriptBuilder = BuilderUtils.CreateBuilder(x => x.Directives.Define("var_test", "1000"));
        var result = GetString(scriptBuilder);
        result.Should().Be("#define var_test 1000");
    }

    [Fact]
    public void FreeText()
    {
        const string anyText = "this is a text";
        var scriptBuilder = BuilderUtils.CreateBuilder(x => x.Directives.FreeText(anyText));
        var result = GetString(scriptBuilder);
        result.Should().Be(anyText);
    }

    [Fact]
    public void IncludeAngleBrackets()
    {
        var scriptBuilder = BuilderUtils.CreateBuilder(x => x.Directives.Include("<file_path>"));
        var result = GetString(scriptBuilder);
        result.Should().Be("#include <file_path>");
    }

    [Fact]
    public void IncludeQuotes()
    {
        var scriptBuilder = BuilderUtils.CreateBuilder(x => x.Directives.Include("file_path"));
        var result = GetString(scriptBuilder);
        result.Should().Be("#include \"file_path\"");
    }

    [Fact]
    public void Undefine()
    {
        var scriptBuilder = BuilderUtils.CreateBuilder(x => x.Directives.Undef("var_test"));
        var result = GetString(scriptBuilder);
        result.Should().Be("#undef var_test");
    }
}