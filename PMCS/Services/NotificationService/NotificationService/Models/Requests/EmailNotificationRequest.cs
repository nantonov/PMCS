namespace Notifications.API.Models.Requests
{
    public class EmailNotificationRequest
    {
        public string RecieverEmailAddress { get; set; }
        public string OwnerName { get; set; }
        public string PetName { get; set; }
        public string Message { get; set; }
    }
}
