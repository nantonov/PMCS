using Schedule.Application.Core.Abstractions.Models;

namespace Schedule.Application.Core.Models.Notifications
{
    public record PersonalAccountNotification(string Message, string UserId) : INotification;
}
