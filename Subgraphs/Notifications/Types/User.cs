namespace Notifications.Types;

public sealed record User(string Username)
{
    public IQueryable<Notification> GetNotifications(
        NotificationsContext context)
        => context.Notifications.Where(t => t.Username == Username);
}