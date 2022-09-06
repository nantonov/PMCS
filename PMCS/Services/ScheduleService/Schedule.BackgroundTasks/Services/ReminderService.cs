using MediatR;
using Schedule.Application.Common.Queries;
using Schedule.Application.Core.Abstractions.Services;
using Schedule.BackgroundTasks.Abstractions;
using Schedule.BackgroundTasks.Settings;
using Serilog;

namespace Schedule.BackgroundTasks.Services
{
    public class ReminderService : IProcessingService
    {
        private readonly IMediator _mediator;
        private readonly INotificationService _notificationService;

        public ReminderService(IMediator mediator, INotificationService notificationService)
        {
            _mediator = mediator;
            _notificationService = notificationService;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Log.Information("Background task started again.");

                var query = new GetRemindersToTriggerQuery(DateTime.UtcNow);

                var reminders = await _mediator.Send(query, stoppingToken);

                if (reminders.Any())
                {
                    foreach (var reminder in reminders)
                    {
                        reminder.Triggered();

                        var notification = await _notificationService.Notify(reminder);

                        Log.Information("Notification {Notification} was send to user.", notification);
                    }
                }

                await Task.Delay(BackgroundTaskSettings.SleepTimeInMilliseconds, stoppingToken);
            }
        }


    }
}
