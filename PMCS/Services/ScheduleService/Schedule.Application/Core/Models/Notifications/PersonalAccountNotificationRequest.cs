using Schedule.Application.Core.Abstractions.Models;

namespace Schedule.Application.Core.Models.Notifications
{
    public record PersonalAccountNotificationRequest(string UserId, string Message) : INotificationRequest;
}