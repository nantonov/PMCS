using Microsoft.Extensions.DependencyInjection;
using Schedule.Application.Core.Abstractions.Services;
using Schedule.Application.Services;

namespace Schedule.Application.DI
{
    public static class ApplicationDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IPetService, PetService>();
        }
    }
}
