using MediatR;

namespace Schedule.Domain.Events
{
    public record ReminderStatusChangedAsDoneEvent(int ReminderId) : INotification;
}
