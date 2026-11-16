namespace BuilderTests;

using System.Collections.Generic;

public class IssigKeysTests : ParameterSectionTestsBase<ISSigKeyEntry>
{
    protected override string SectionName => "ISSigKeys";

    protected override Dictionary<string, string> ReferenceData => new()
    {
        { "Name", "\"MyKey1\"" },
        { "Group", "\"exesigner docsigner\"" },
        { "KeyID", "\"def0147c3bbc17ab99bf7b7a9c2de1390283f38972152418d7c2a4a7d7131a38\"" },
        { "KeyFile", "\"MyKey1.ispublickey\"" },
        { "PublicX", "\"515dc7d6c16d4a46272ceb3d158c5630a96466ab4d948e72c2029d737c823097\"" },
        { "PublicY", "\"f3c21f6b5156c52a35f6f28016ee3e31a3ded60c325b81fb7b1f88c221081a61\"" },
        { "RuntimeID", "\"def01\"" },
    };
}