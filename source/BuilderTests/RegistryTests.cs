namespace BuilderTests
{
    using System.Collections.Generic;
    using InnoSetup.ScriptBuilder;

    public class RegistryTests : ParameterSectionTestsBase<RegistryEntry>
    {
        protected override string SectionName => "Registry";

        protected override Dictionary<string, string> ReferenceData => new()
        {
            { "Root", "hkcu" },
            { "Subkey", "\"Subkey\"" },
            { "ValueName", "\"ValueName\"" },
            { "ValueType", "string" },
            { "ValueData", "\"ValueData\"" },
            { "Components", "\"Components\"" },
            { "Tasks", "\"Tasks\"" },
            { "Languages", "\"Languages\"" },
            { "MinVersion", "\"MinVersion\"" },
            { "OnlyBelowVersion", "\"OnlyBelowVersion\"" },
            { "Permissions", "service-full admins-modify" },
            { "Flags", "createvalueifdoesntexist noerror" },
        };
    }
}