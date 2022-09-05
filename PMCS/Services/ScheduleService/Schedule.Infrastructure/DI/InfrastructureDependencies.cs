using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schedule.Domain.Repositories;
using Schedule.Infrastructure.Repositories;

namespace Schedule.Infrastructure.DI
{
    public static class InfrastructureDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IReminderRepository, ReminderRepository>();


            services.AddDbContext<ScheduleDbContext>(op =>
                {
                    op.UseSqlServer(config.GetConnectionString("DbConnection"));
                }
            );
        }
    }
}
