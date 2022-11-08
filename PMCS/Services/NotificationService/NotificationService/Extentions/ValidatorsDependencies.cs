using FluentValidation;
using Notifications.API.Models.Requests;
using Notifications.API.Validators;

namespace Notifications.API.Extentions
{
    public static class ValidatorsDependencies
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<SendEmailNotificationViewModel>, EmailRequestValidator>()
                .AddScoped<IValidator<SendClientNotificationViewModel>, ClientRequestValidator>();
        }
    }
}
