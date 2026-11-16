namespace InnoSetup.ScriptBuilder
{
    public interface IComponentsAndTasksBuilder<TBuilder>
    {
        TBuilder Components(string value);
        TBuilder Tasks(string value);

        /// <summary>
        /// The name of a function that is to be called once just before an entry is installed.
        /// The function must either be a custom function in the [Code] section or a support function.
        /// <para>
        /// May include a comma separated list of parameters that Setup should pass to the function.
        /// Allowed parameter types are String, Integer and Boolean. String parameters may include constants.
        /// These constants will not be automatically expanded. If you want to pass an expanded constant, there's one
        /// special support function that may be called from within a parameter list for this: ExpandConstant.
        /// </para>
        /// </summary>
        TBuilder BeforeInstall(string value);

        /// <summary>
        /// The name of a function that is to be called once just after an entry is installed.
        /// The function must either be a custom function in the [Code] section or a support function.
        /// <para>
        /// May include a comma separated list of parameters that Setup should pass to the function.
        /// Allowed parameter types are String, Integer and Boolean. String parameters may include constants.
        /// These constants will not be automatically expanded. If you want to pass an expanded constant, there's one
        /// special support function that may be called from within a parameter list for this: ExpandConstant.
        /// </para>
        /// </summary>
        TBuilder AfterInstall(string value);
    }
}