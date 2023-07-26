namespace Notifications.Data;

public class DatabaseHelper
{
    public static async Task SeedDatabaseAsync(WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<NotificationsContext>();
        if (await context.Database.EnsureCreatedAsync())
        {
            await context.Notifications.AddRangeAsync(
                new Notification
                {
                    Message = "Account login on new device",
                    Username = "@ada"
                },
                new Notification
                {
                    Message = "It seems like your account was hacked",
                    Username = "@alan"
                });
            await context.SaveChangesAsync();
        }
    }

}