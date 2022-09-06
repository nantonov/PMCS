using Microsoft.Extensions.DependencyInjection;
using Schedule.BackgroundTasks.Abstractions;
using Schedule.BackgroundTasks.Services;
using Schedule.BackgroundTasks.Tasks;


namespace Schedule.BackgroundTasks.DI
{
    public static class BackgroundServicesRegistration
    {
        public static void AddBackgroundTasks(this IServiceCollection services)
        {
            services.AddHostedService<ReminderBackgroundService>();
            services.AddScoped<IProcessingService, ReminderService>();
        }
    }
}
