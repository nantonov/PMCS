﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schedule.BackgroundTasks.Abstractions;

namespace Schedule.BackgroundTasks.Tasks
{
    public class ReminderBackgroundService : BackgroundService
    {
        public IServiceProvider Services { get; }

        public ReminderBackgroundService(IServiceProvider services)
        {
            Services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken cancellationToken)
        {
            using var scope = Services.CreateScope();
            var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IProcessingService>();

            await scopedProcessingService.DoWork(cancellationToken);
        }
    }
}
