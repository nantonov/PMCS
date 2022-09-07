using MediatR;
using Schedule.Application.Common.Queries;
using Schedule.BackgroundTasks.Abstractions;
using Schedule.BackgroundTasks.Settings;
using Schedule.Domain.Repositories;
using Serilog;

namespace Schedule.BackgroundTasks.Services
{
    public class ReminderService : IProcessingService
    {
        private readonly IMediator _mediator;
        private readonly IReminderRepository _reminderRepository;

        public ReminderService(IMediator mediator, IReminderRepository reminderRepository)
        {
            _mediator = mediator;
            _reminderRepository = reminderRepository;
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

                        await _reminderRepository.Update(reminder, stoppingToken);
                        Log.Information("Reminder {Reminder} was triggered.", reminder);
                    }
                }

                await Task.Delay(BackgroundTaskSettings.SleepTimeInMilliseconds, stoppingToken);
            }
        }


    }
}
