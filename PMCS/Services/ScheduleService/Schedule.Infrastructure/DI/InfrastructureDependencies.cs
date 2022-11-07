using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Schedule.Application.Configuration;
using Schedule.Domain.Repositories;
using Schedule.Infrastructure.Repositories;

namespace Schedule.Infrastructure.DI
{
    public static class InfrastructureDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient(ClientsConfiguration.AuthClientName,
                client => client.BaseAddress = new Uri(ClientsConfiguration.AuthServiceAddress))
                .AddTransientHttpErrorPolicy(x => x.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(300)));

            services.AddHttpClient(ClientsConfiguration.PetClientName,
                client => client.BaseAddress = new Uri(ClientsConfiguration.PetServiceAddress));

            services.AddHttpClient(ClientsConfiguration.NotificationClientName,
                client => client.BaseAddress = new Uri(ClientsConfiguration.NotificationServiceAddress));

            services.AddDbContext<ScheduleDbContext>(op =>
                {
                    op.UseSqlServer(config.GetConnectionString("DbConnection"));
                }
            );

            services.AddTransient<IReminderRepository, ReminderRepository>();
        }
    }
}
