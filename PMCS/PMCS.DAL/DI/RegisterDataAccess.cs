using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMCS.DAL.Entities;

namespace PMCS.DAL.DI
{
    public static class DataAccessRegistration
    {
        public static void RegisterDataAccessDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppContext>(op =>
                {
                    op.UseSqlServer(config.GetConnectionString("DbConnection"));
                }
            );
        }
    }
}