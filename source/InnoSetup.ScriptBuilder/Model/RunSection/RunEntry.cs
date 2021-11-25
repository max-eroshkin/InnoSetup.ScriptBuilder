namespace InnoSetup.ScriptBuilder.Model.RunSection
{
    public class RunEntry : CommonParameterSectionEntryBase, IHazComponentsAndTasks
    {
        public string Filename { get; set; }

        public string Description { get; set; }

        public string Parameters { get; set; }

        public string WorkingDir { get; set; }

        public string StatusMsg { get; set; }

        public string RunOnceId { get; set; }

        public string Verb { get; set; }

        public RunFlags? Flags { get; set; }

        public string Components { get; set; }

        public string Tasks { get; set; }
    }
}