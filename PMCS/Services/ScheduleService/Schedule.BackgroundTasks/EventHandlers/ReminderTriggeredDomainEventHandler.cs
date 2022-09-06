using MediatR;
using Schedule.Domain.Events;
using Schedule.Domain.Repositories;

namespace Schedule.BackgroundTasks.EventHandlers
{
    public class ReminderTriggeredDomainEventHandler : INotificationHandler<ReminderTriggeredDomainEvent>
    {
        private readonly IReminderRepository _repository;

        public ReminderTriggeredDomainEventHandler(IReminderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ReminderTriggeredDomainEvent notification, CancellationToken cancellationToken)
        {
            var reminder = notification.Reminder;

            await _repository.Update(reminder, cancellationToken);
        }
    }
}
