namespace BuilderTests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using FluentAssertions;
    using InnoSetup.ScriptBuilder;
    using Xunit;

    public class BuilderTests
    {
        [Fact]
        public void NamingConsistency()
        {
            var builder = BuilderUtils.CreateBuilder(_ => { });
            var builderType = builder.GetType();
            var builderProperties = builderType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.PropertyType.Name.EndsWith("Builder"))
                .ToList();

            foreach (var property in builderProperties)
            {
                var sectionBuilder = property.GetValue(builder)!;
                var nameProperty = sectionBuilder.GetType().GetProperty("SectionName") 
                                   ?? throw new InvalidCastException($"Builder {sectionBuilder.GetType()} mast have SectionName");
                var name = nameProperty.GetValue(sectionBuilder);
                name.Should().Be(property.Name);
            }
        }

        [Fact]
        public void ModelAllPropertiesNullable()
        {
            var baseType = typeof(ModelBase);
            var modelTypes = baseType.Assembly.GetTypes()
                .Where(x => x.IsAssignableTo(baseType))
                .ToList();
            var properties = modelTypes.SelectMany(x => x
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(x => x.Name != "Aux"))
                .ToList();

            properties.Should().OnlyContain(x => IsNullable(x.PropertyType));
        }

        [Fact]
        public void WriteFile()
        {
            BuilderUtils.Build(
                c =>
                {
                    c.Directives
                        .Define("MyAppName", "My Program")
                        .Include(@"c:\dir\file.iss")
                        .Include("<file.iss>")
                        .FreeText(";comments")
                        .Undef("var1");
                    
                    c.Setup.Create("BimTools.Support")
                        .AppVersion("1.2.5.1634640046")
                        .DefaultDirName(@"{userappdata}\Autodesk\Revit\Addins\2019\SupportTools")
                        .PrivilegesRequired(PrivilegesRequired.Lowest)
                        .OutputBaseFilename("BimTools.Support_2021_1.2.5.1634640046")
                        .SetupIconFile("trayIcon.ico")
                        .UninstallDisplayIcon("trayIcon.ico")
                        .DisableDirPage(YesNo.Yes);

                    c.Files.CreateEntry(source: @"bin\*", destDir: InnoConstants.Directories.App)
                        .Flags(FileFlags.IgnoreVersion | FileFlags.RecurseSubdirs);
                    c.Files.CreateEntry(source: "SupportTools.addin",
                        destDir: @"{userappdata}\Autodesk\Revit\Addins\2019");
                    c.Files.CreateEntry(source: @"bin\Fonts\GraphikLCG-Medium.ttf", destDir: @"{autofonts}")
                        .FontInstall("Graphik LCG")
                        .Flags(FileFlags.OnlyIfDestFileExists | FileFlags.UninsNeverUninstall);
                    c.Files.CreateEntry(source: @"bin\Fonts\GraphikLCG-Regular.ttf", destDir: @"{autofonts}")
                        .FontInstall("Graphik LCG")
                        .Flags(FileFlags.OnlyIfDestFileExists | FileFlags.UninsNeverUninstall);
                    c.Files.CreateEntry(source: @"bin\Fonts\GraphikLCG-gfjfjfj.ttf", destDir: @"{autofonts}")
                        .FontInstall("Graphik 111")
                        .AddPermission(Sids.System, Permissions.ReadExec)
                        .AddPermission(Sids.Users, Permissions.Modify)
                        .Flags(FileFlags.OnlyIfDestFileExists | FileFlags.UninsNeverUninstall);
                },
                "test_build.iss");
        }

        [Fact]
        public void WriteString()
        {
            var scriptBuilder = new TestBuilder();
            var result = scriptBuilder.ToString();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void TestBuilderContainsAllAvailableSections()
        {
            var builder = new TestBuilder();
            var builderType = builder.GetType();
            var builderProperties = builderType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.PropertyType.Name.EndsWith("Builder"))
                .ToList();
            
            var iss = new TestBuilder().ToString();
            var testBuilderSections = TestUtils.GetSections(iss).ToList();

            var classSections = builderProperties.Select(x =>
            {
                var sectionBuilder = x.GetValue(builder);
                var nameProperty = sectionBuilder.GetType().GetProperty("SectionName");
                return (string)nameProperty.GetValue(sectionBuilder);
            });

            classSections.Where(x => x != "Directives")
                .Should().OnlyContain(x => testBuilderSections.Any(t => t.Name == x));
        }

        private static bool IsNullable(Type type)
        {
            if (!type.IsValueType) return true;
            if (Nullable.GetUnderlyingType(type) != null) return true;
            return false;
        }
    }
}