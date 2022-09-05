namespace Notifications.BLL.Models.Payloads
{
    public class EmailNotificationPayload : NotificationPayload
    {
        public string RecieverEmailAddress { get; set; }
        public string Subject { get; set; }
    }
}
