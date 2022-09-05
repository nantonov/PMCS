using MediatR;
using Schedule.Domain.Entities;
using Schedule.Domain.Enums;

namespace Schedule.Application.Common.Commands
{
    public record UpdateReminderCommand(
        int Id,
        DateTime TriggerDateTime,
        string NotificationMessage,
        NotificationType NotificationType,
        ActionToRemindType ActionToRemindType) : IRequest<Reminder>;
}
