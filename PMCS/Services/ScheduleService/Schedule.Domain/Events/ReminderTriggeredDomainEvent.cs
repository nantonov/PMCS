using MediatR;
using Schedule.Domain.Entities;

namespace Schedule.Domain.Events
{
    public record ReminderTriggeredDomainEvent(Reminder Reminder) : INotification;
}
