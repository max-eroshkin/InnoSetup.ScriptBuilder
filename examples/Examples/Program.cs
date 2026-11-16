namespace Examples;

using System;
using InnoSetup.ScriptBuilder;

internal class Program
{
    private static void Main(string[] args)
    {
        BuildFile();

        BuildFile2();

        BuildFInPlace();

        BuildString();
    }

    private static void BuildString()
    {
        var builder = BuilderUtils.CreateBuilder(builder =>
        {
            builder.Setup.Create("BimTools.Support")
                .AppVersion("1.2.5.1634640046")
                .DefaultDirName(@"{userappdata}\SupportTools");
            builder.Files.CreateEntry(@"bin\*", InnoConstants.Directories.App)
                .Flags(FileFlags.IgnoreVersion | FileFlags.RecurseSubdirs);
        });
        //new DemoBuilder();
        var result = builder.ToString();
        Console.WriteLine("\nString result:");
        Console.WriteLine(result);
    }

    private static void BuildFile()
    {
        var builder = new DemoBuilder();
        builder.Build("demo.iss");

        Console.WriteLine("demo.iss built");
    }

    private static void BuildFile2()
    {
        BuilderUtils.Build<DemoBuilder>("demo2.iss");

        Console.WriteLine("demo2.iss built");
    }

    private static void BuildFInPlace()
    {
        BuilderUtils.Build(
            builder =>
            {
                builder.Setup.Create("BimTools.Support")
                    .AppVersion("1.2.5.1634640046")
                    .DefaultDirName(@"{userappdata}\SupportTools");
                builder.Files.CreateEntry(@"bin\*", InnoConstants.Directories.App)
                    .Flags(FileFlags.IgnoreVersion | FileFlags.RecurseSubdirs);
            },
            "inplace.iss");

        Console.WriteLine("inplace.iss built");
    }
}