namespace Notifications.API.Models.Requests
{
    public class SendClientNotificationViewModel
    {
        public string? Message { get; set; }
        public string? UserId { get; set; }
    }
}
