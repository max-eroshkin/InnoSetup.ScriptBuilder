namespace InnoSetup.ScriptBuilder
{
    using System;
    using System.IO;
    using System.Reflection;
    using Model;
    using Model.SetupSection;

    public class SetupBuilder : SectionBuilderBase<SetupBuilder, SetupSection>, ISetupBuilder, IBuilder
    {
        public SetupBuilder Create(string appName)
        {
            Data = new SetupSection();
            return AppName(appName);
        }

        public SetupBuilder AppVerName(string value) => SetPropertyValue(value);
        public SetupBuilder AppId(string value) => SetPropertyValue(value);
        public SetupBuilder AppCopyright(string value) => SetPropertyValue(value);
        public SetupBuilder AppPublisher(string value) => SetPropertyValue(value);
        public SetupBuilder AppPublisherURL(string value) => SetPropertyValue(value);
        public SetupBuilder AppSupportPhone(string value) => SetPropertyValue(value);
        public SetupBuilder AppSupportURL(string value) => SetPropertyValue(value);
        public SetupBuilder AppUpdatesURL(string value) => SetPropertyValue(value);
        public SetupBuilder AppVersion(string value) => SetPropertyValue(value);
        public SetupBuilder DefaultDirName(string value) => SetPropertyValue(value);
        public SetupBuilder DefaultGroupName(string value) => SetPropertyValue(value);
        public SetupBuilder BaseFilename(string value) => SetPropertyValue(value);
        public SetupBuilder UninstallFilesDir(string value) => SetPropertyValue(value);
        public SetupBuilder UninstallDisplayName(string value) => SetPropertyValue(value);
        public SetupBuilder UninstallDisplayIcon(string value) => SetPropertyValue(value);
        public SetupBuilder AppMutex(string value) => SetPropertyValue(value);
        public SetupBuilder DefaultUserInfoName(string value) => SetPropertyValue(value);
        public SetupBuilder DefaultUserInfoOrg(string value) => SetPropertyValue(value);
        public SetupBuilder DefaultUserInfoSerial(string value) => SetPropertyValue(value);
        public SetupBuilder AppReadmeFile(string value) => SetPropertyValue(value);
        public SetupBuilder AppContact(string value) => SetPropertyValue(value);
        public SetupBuilder AppComments(string value) => SetPropertyValue(value);
        public SetupBuilder AppModifyPath(string value) => SetPropertyValue(value);
        public SetupBuilder CreateUninstallRegKey(string value) => SetPropertyValue(value);
        public SetupBuilder Uninstallable(string value) => SetPropertyValue(value);
        public SetupBuilder CloseApplicationsFilter(string value) => SetPropertyValue(value);
        public SetupBuilder SetupMutex(string value) => SetPropertyValue(value);
        public SetupBuilder ChangesEnvironment(string value) => SetPropertyValue(value);
        public SetupBuilder ChangesAssociations(string value) => SetPropertyValue(value);
        public SetupBuilder InfoBeforeText(string value) => SetPropertyValue(value);
        public SetupBuilder LicenseText(string value) => SetPropertyValue(value);
        public SetupBuilder InfoAfterText(string value) => SetPropertyValue(value);
        public SetupBuilder CompiledCodeText(string value) => SetPropertyValue(value);
        public SetupBuilder NumLanguageEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumCustomMessageEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumPermissionEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumTypeEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumComponentEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumTaskEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumDirEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumFileEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumFileLocationEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumIconEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumIniEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumRegistryEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumInstallDeleteEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumUninstallDeleteEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumRunEntries(int value) => SetPropertyValue(value);
        public SetupBuilder NumUninstallRunEntries(int value) => SetPropertyValue(value);
        public SetupBuilder BackColor(long value) => SetPropertyValue(value);
        public SetupBuilder BackColor2(long value) => SetPropertyValue(value);
        public SetupBuilder DirExistsWarning(YesNo value) => SetPropertyValue(value);
        public SetupBuilder ShowLanguageDialog(YesNo value) => SetPropertyValue(value);
        public SetupBuilder UninstallLogMode(UninstallLogMode value) => SetPropertyValue(value);
        public SetupBuilder WizardImageAlphaFormat(WizardImageAlphaFormat value) => SetPropertyValue(value);
        public SetupBuilder WizardSizePercentX(int value) => SetPropertyValue(value);
        public SetupBuilder WizardSizePercentY(int value) => SetPropertyValue(value);
        public SetupBuilder ExtraDiskSpaceRequired(long value) => SetPropertyValue(value);
        public SetupBuilder SlicesPerDisk(int value) => SetPropertyValue(value);
        public SetupBuilder UninstallDisplaySize(long value) => SetPropertyValue(value);
        public SetupBuilder DisableDirPage(YesNo value) => SetPropertyValue(value);
        public SetupBuilder DisableProgramGroupPage(YesNo value) => SetPropertyValue(value);
        public SetupBuilder PrivilegesRequired(PrivilegesRequired value) => SetPropertyValue(value);

        public SetupBuilder PrivilegesRequiredOverridesAllowed(SetupPrivilegesRequiredOverrides value) =>
            SetPropertyValue(value);

        public SetupBuilder Options(SetupOption value) => SetPropertyValue(value);
        public SetupBuilder OutputDir(string value) => SetPropertyValue(value);
        public SetupBuilder OutputBaseFilename(string value) => SetPropertyValue(value);
        public SetupBuilder OutputManifestFile(string value) => SetPropertyValue(value);
        public SetupBuilder SetupIconFile(string value) => SetPropertyValue(value);

        public void Write(TextWriter writer)
        {
            _ = Data ?? throw new IssBuilderException("[Setup] section not created");
            writer.WriteLine("[Setup]");
            WriteProperties(writer);
            WriteAux(writer);
        }

        private SetupBuilder AppName(string value) => SetPropertyValue(value);

        private void WriteProperties(TextWriter writer)
        {
            var type = Data.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo info in properties)
            {
                var value = info.GetValue(Data);
                if (value is null)
                    continue;
                
                var str = value.GetString();
                if (str is not null)
                    writer.WriteLine($"{info.Name}={str}");
            }
        }
        
        private void WriteAux(TextWriter writer)
        {
            foreach (var parameter in Data.Aux)
            {
                if (parameter.Value.value is null)
                    continue;
                
                var str = parameter.Value.value.GetString(parameter.Value.needQuotes);
                if (str is not null)
                    writer.WriteLine($"{parameter.Key}={str}");
            }
        }
    }
}