namespace InnoSetup.ScriptBuilder
{
    using System;
    using System.IO;

    public static class FileHelper
    {
        public static void Build<TBuilder>(string path)
            where TBuilder : ScriptBuilderBase, new()
        {
            Build(typeof(TBuilder), path);
        }

        public static void Build(Type builderType, string path)
        {
            var builder = (ScriptBuilderBase)Activator.CreateInstance(builderType);
            Build(builder, path);
        }

        public static void Build(ScriptBuilderBase builder, string path)
        {
            using var writer = new StreamWriter(path, false);
            builder.Write(writer);
        }

        public static void Build(Action<ScriptBuilderBase> config, string path)
        {
            Build(new DelegateScriptBuilder(config), path);
        }
    }
}