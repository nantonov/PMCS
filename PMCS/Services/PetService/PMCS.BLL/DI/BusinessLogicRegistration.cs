using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMCS.BLL;
using PMCS.BLL.Interfaces.Services;
using PMCS.BLL.Services;
using PMCS.DAL.DI;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Services;
using Polly;

namespace PMCS.BLL.DI
{
    public static class BusinessLogicRegistration
    {
        public static void RegisterBusinessLogicDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IPetService, PetService>();
            services.AddTransient<IMealService, MealService>();
            services.AddTransient<IVaccineService, VaccineService>();
            services.AddTransient<IWalkingService, WalkingService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddHttpClient(ClientsConfiguration.ScheduleClientName,
                client => client.BaseAddress = new Uri(ClientsConfiguration.ScheduleServiceAddress))
                .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(ClientsConfiguration.ScheduleClientRetryCount,
                    retryNumber => TimeSpan.FromMilliseconds(ClientsConfiguration.ScheduleSleepDurationInMilliseconds)));

            services.RegisterDataAccessDependencies(configuration);
        }
    }
}
