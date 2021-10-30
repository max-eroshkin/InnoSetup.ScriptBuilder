namespace InnoSetup.ScriptBuilder.Model.FileSection
{
    public class GroupPermission
    {
        public GroupPermission(Sids group, Permissions permission)
        {
            Group = group;
            Permission = permission;
        }

        public Sids Group { get; }

        public Permissions Permission { get; }
    }
}