using Notifications.BLL.Resources.Constants;

namespace Notifications.BLL.Models.Payloads
{
    public class EmailNotificationPayload : NotificationPayload
    {
        public string RecieverEmailAddress { get; set; }
        public string OwnerName { get; set; }
        public string PetName { get; set; }
        public string Subject { get; } = EmailConfiguration.EMAIL_SUBJECT;
    }
}
