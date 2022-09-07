using MediatR;
using Schedule.Application.Core.Abstractions.Services;
using Schedule.Domain.Events;
using Serilog;

namespace Schedule.BackgroundTasks.EventHandlers
{
    public class ReminderTriggeredDomainEventHandler : INotificationHandler<ReminderTriggeredDomainEvent>
    {
        private readonly INotificationService _notificationService;

        public ReminderTriggeredDomainEventHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(ReminderTriggeredDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            var reminder = domainEvent.Reminder;

            var notification = await _notificationService.Notify(reminder);

            if (notification != null)
            {
                Log.Information("Notification {Notification} was sent.", notification);
            }
        }
    }
}
