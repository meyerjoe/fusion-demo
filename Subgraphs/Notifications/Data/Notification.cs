namespace Notifications.Data;

[Index(nameof(Username))]
public class Notification
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(1024)]
    public string? Message { get; set; }

    [Required]
    public string? Username { get; set; }
}
