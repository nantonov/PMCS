using Schedule.Application.Core.Abstractions.Models;

namespace Schedule.Application.Core.Models.Notifications
{
    public record EmailNotification(string RecieverEmailAddress, string Message, string Subject) : INotification;
}
