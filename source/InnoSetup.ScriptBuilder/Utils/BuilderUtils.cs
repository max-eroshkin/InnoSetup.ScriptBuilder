namespace InnoSetup.ScriptBuilder
{
    using System;
    using System.IO;

    public static class BuilderUtils
    {
        public static IssBuilder CreateBuilder(Action<IssBuilder> config)
        {
            return new DelegateScriptBuilder(config);
        }

        public static void Build<TBuilder>(string path)
            where TBuilder : IssBuilder, new()
        {
            Build(typeof(TBuilder), path);
        }

        public static void Build(Type builderType, string path)
        {
            var builder = (IssBuilder)Activator.CreateInstance(builderType);
            builder.Build(path);
        }

        public static void Build(this IssBuilder builder, string path)
        {
            using var writer = new StreamWriter(path, false);
            builder.Write(writer);
        }

        public static void Build(Action<IssBuilder> config, string path)
        {
            Build(CreateBuilder(config), path);
        }
    }
}