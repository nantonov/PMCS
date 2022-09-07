using Schedule.Application.Core.Abstractions.Models;

namespace Schedule.Application.Core.Models.Notifications
{
    public record EmailNotificationRequest(string RecieverEmailAddress, string Message) : INotificationRequest;
}
