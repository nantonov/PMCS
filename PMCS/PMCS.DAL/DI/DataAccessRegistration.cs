using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DAL.Repositories;

namespace PMCS.DAL.DI
{
    public static class DataAccessRegistration
    {
        public static void RegisterDataAccessDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IOwnerRepository,OwnerRepository>();
            services.AddTransient<IPetRepository, PetRepository>();

            services.AddDbContext<AppContext>(op =>
                {
                    op.UseSqlServer(config.GetConnectionString("DbConnection"));
                }
            );
        }
    }
}