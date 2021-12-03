namespace InnoSetup.ScriptBuilder
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