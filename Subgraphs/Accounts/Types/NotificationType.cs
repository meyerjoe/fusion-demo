namespace Demo.Accounts.Types;

public sealed record Notification([property: ID<Notification>] int Id)
{
}

[ExtendObjectType<Notification>]
public static class NotificationType
{
    public static async Task<User?> GetRecipientAsync(
        string username,
        UserByNameDataLoader userByName,
        CancellationToken cancellationToken)
        => await userByName.LoadAsync(username, cancellationToken);
}