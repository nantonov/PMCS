using Notifications.BLL.Resources.Constants;

namespace Notifications.BLL.Models.DTOs
{
    public class EmailNotification : Notification
    {
        public string? ReceiverEmailAddress { get; set; }
        public string? Subject { get; } = EmailConfiguration.EMAIL_SUBJECT;
    }
}
