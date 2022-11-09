using Schedule.Application.Core.Abstractions.Models;

namespace Schedule.Application.Core.Models.Notifications
{
    public record EmailNotificationRequest(string ReceiverEmailAddress, string Message) : INotificationRequest;
}
