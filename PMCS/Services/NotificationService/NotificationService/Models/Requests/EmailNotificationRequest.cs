namespace Notifications.API.Models.Requests
{
    public class EmailNotificationRequest
    {
        public string? ReceiverEmailAddress { get; set; }
        public string? Message { get; set; }
    }
}
