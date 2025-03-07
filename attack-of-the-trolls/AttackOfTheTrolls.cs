enum AccountType
{
    Moderator,
    User,
    Guest,
}

[Flags]
enum Permission
{
    None = 0,
    Read = 1,
    Write = 2,
    Delete = 4,
    All = Read | Write | Delete,
}

static class Permissions
{
    public static Permission Default(AccountType accountType) =>
        accountType switch
        {
            AccountType.Moderator => Permission.All,
            AccountType.User => Permission.Read | Permission.Write,
            AccountType.Guest => Permission.Read,
            _ => Permission.None,
        };

    public static Permission Grant(Permission current, Permission grant) => current | grant;

    public static Permission Revoke(Permission current, Permission revoke) => current & ~revoke;

    public static bool Check(Permission current, Permission check) => (current & check) == check;
}
