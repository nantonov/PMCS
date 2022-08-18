using Microsoft.Extensions.DependencyInjection;
using Notifications.BLL.Interfaces.Services;
using Notifications.BLL.Services;

namespace Notifications.BLL.DI
{
    public static class BusinessLogicRegistration
    {
        public static void RegisterBusinessLogicDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
