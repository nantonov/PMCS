using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Schedule.Application.Configuration;
using Schedule.Application.Core.Abstractions.Services;
using Schedule.Application.RetryPolicy;
using Schedule.Domain.Repositories;
using Schedule.Infrastructure.Repositories;
using Schedule.Infrastructure.Services;

namespace Schedule.Infrastructure.DI
{
    public static class InfrastructureDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient(ClientsConfiguration.AuthClientName,
                client => client.BaseAddress = new Uri(ClientsConfiguration.AuthServiceAddress))
                .AddTransientHttpErrorPolicy(x => x.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(300))); ;

            services.AddHttpClient(ClientsConfiguration.PetClientName,
                client => client.BaseAddress = new Uri(ClientsConfiguration.PetServiceAddress))
                .AddPolicyHandler(ResilientPolicy.TransientErrorRetryPolicy)
                .AddPolicyHandler(ResilientPolicy.CircuitBreakerPolicy);

            services.AddHttpClient(ClientsConfiguration.NotificationClientName,
                client => client.BaseAddress = new Uri(ClientsConfiguration.NotificationServiceAddress))
                .AddPolicyHandler(ResilientPolicy.TransientErrorRetryPolicy)
                .AddPolicyHandler(ResilientPolicy.CircuitBreakerPolicy);

            services.AddDbContext<ScheduleDbContext>(op =>
                {
                    op.UseSqlServer(config.GetConnectionString("DbConnection"));
                }
            );

            services.AddTransient<IReminderRepository, ReminderRepository>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
