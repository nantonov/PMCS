using MediatR;
using Schedule.Domain.Entities;
using Schedule.Domain.Enums;

namespace Schedule.Application.Common.Commands
{
    public record AddReminderCommand(
        DateTime TriggerDateTime,
        int PetId,
        int UserId,
        string NotificationMessage,
        NotificationType NotificationType,
        ActionToRemindType ActionToRemindType) : IRequest<Reminder>;
}
