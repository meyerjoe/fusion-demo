namespace Notifications.Types;

internal static class NotificationDataLoaders
{
    
    [DataLoader]
    public static async Task<IReadOnlyDictionary<int, Notification>> GetNotificationByIdAsync(
        IReadOnlyList<int> ids,
        NotificationsContext context,
        CancellationToken cancellationToken)
        => await context.Notifications
            .Where(t => ids.Contains(t.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    
    [DataLoader]
    public static async Task<ILookup<string, Notification>> GetNotificationsByUsernameAsync(
        IReadOnlyList<string> usernames,
        NotificationsContext context,
        CancellationToken cancellationToken)
    {
        var notifications = await context.Notifications
            .Where(t => usernames.Contains(t.Username))
            .ToListAsync(cancellationToken);

        return notifications.ToLookup(t => t.Username);
    }
}