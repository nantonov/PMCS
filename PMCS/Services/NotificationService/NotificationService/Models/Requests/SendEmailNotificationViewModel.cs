namespace Notifications.API.Models.Requests
{
    public class SendEmailNotificationViewModel
    {
        public string? ReceiverEmailAddress { get; set; }
        public string? Message { get; set; }
    }
}
