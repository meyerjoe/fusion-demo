namespace Notifications.Data;

public class NotificationsContext : DbContext
{
    public NotificationsContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Notification> Notifications => Set<Notification>();

}