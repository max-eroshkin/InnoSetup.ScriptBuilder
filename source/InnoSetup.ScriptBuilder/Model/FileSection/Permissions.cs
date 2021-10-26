using System;

namespace InnoSetup.ScriptBuilder
{
    [Flags]
    public enum Permissions
    {
        ReadExec = 1,
        Modify = 2,
        Full = 4
    }

    public enum Sids
    {
        Admins,
        AuthUsers,
        CreatorOwner,
        Everyone,
        Guests,
        NetworkService,
        PowerUsers,
        Service,
        System,
        Users
    }

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