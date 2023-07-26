namespace Notifications.Types;

[QueryType]
public static class Query
{
    [NodeResolver]
    public static async Task<Notification?> GetNotificationByIdAsync(
        int id,
        NotificationByIdDataLoader notificationByIdDataLoader,
        CancellationToken cancellationToken)
        => await notificationByIdDataLoader.LoadAsync(id, cancellationToken);
    
    [UsePaging]
    public static IQueryable<Notification> GetNotifications(
        NotificationsContext context)
        => context.Notifications.OrderBy(t => t.Username);

    [UsePaging]
    public static IQueryable<Notification> GetNotificationsByUsername(
        string username,
        NotificationsContext context)
        => context.Notifications.Where(t => t.Username == username);

    public static User GetUserByUsername(string username)
        => new User(username);

}