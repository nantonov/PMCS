namespace Notifications.BLL.Models.Payloads
{
    public class EmailNotificationPayload : NotificationPayload
    {
        public string? ReceiverEmailAddress { get; set; }
        public string? Subject { get; set; }
    }
}
