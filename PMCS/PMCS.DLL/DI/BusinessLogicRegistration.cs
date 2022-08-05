using Microsoft.Extensions.DependencyInjection;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Services;

namespace PMCS.DLL.DI
{
    public static class BusinessLogicRegistration
    {
        public static void RegisterBusinessLogicDependencies(this IServiceCollection services)
        {
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IPetService, PetService>();
            services.AddTransient<IMealService, MealService>();
            services.AddTransient<IVaccineService, VaccineService>();
        }
    }
}
