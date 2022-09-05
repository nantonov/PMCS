using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Schedule.Application.DI
{
    public static class ApplicationDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
