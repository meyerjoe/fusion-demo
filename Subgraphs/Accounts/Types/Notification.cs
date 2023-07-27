namespace Demo.Accounts.Types;

public sealed record Notification([property: ID<Notification>] int Id)
{
    public async Task<User?> GetUser(
        string username,
        AccountContext context)
        => await context.Users.FirstOrDefaultAsync(e => e.Username == username);
}

/*    
    public async Task<User?> GetUser(
        UserByNameDataLoader userByName,
        CancellationToken cancellationToken)
        => await userByName.LoadAsync(Username, cancellationToken);
        */