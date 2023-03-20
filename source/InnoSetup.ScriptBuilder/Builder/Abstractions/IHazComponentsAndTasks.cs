﻿namespace InnoSetup.ScriptBuilder
{
    /// <summary>
    /// There are two optional parameters (Components and Taks) that are supported by all sections whose entries
    /// are separated into parameters, except [Types], [Components] and [Tasks]. See <a href="https://jrsoftware.org/ishelp/index.php?topic=componentstasksparams">ISS documentation</a>.
    /// </summary>
    public interface IHazComponentsAndTasks
    {
        /// <summary>
        /// A space separated list of component names.
        /// </summary>
        public string Components { get; set; }

        /// <summary>
        /// A space separated list of task names.
        /// </summary>
        public string Tasks { get; set; }

        public string BeforeInstall { get; set; }

        public string AfterInstall { get; set; }
    }
}