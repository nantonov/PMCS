using IdentityModel;
using IdentityServer.Configuration;
using IdentityServer.Models;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static IdentityServer.Data.Initializaton.InitializationData;

namespace IdentityServer.Data.Initializaton
{
    public static class DataInitializer
    {
        public static async Task InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();

                context.Database.Migrate();

                if (!context.Clients.Any())
                {
                    foreach (var client in ServerConfiguration.Clients)
                    {
                        await context.Clients.AddAsync(client.ToEntity());
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in ServerConfiguration.IdentityResources)
                    {
                        await context.IdentityResources.AddAsync(resource.ToEntity());
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in ServerConfiguration.ApiResources)
                    {
                        await context.ApiResources.AddAsync(resource.ToEntity());
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var scope in ServerConfiguration.ApiScopes)
                    {
                        await context.ApiScopes.AddAsync(scope.ToEntity());
                    }
                    await context.SaveChangesAsync();
                }

                if (await userManager.FindByNameAsync(InitialUser.UserName) == null)
                {
                    await userManager.CreateAsync(InitialUser, "secret");

                    await userManager.AddClaimAsync(InitialUser, new Claim(JwtClaimTypes.Email, InitialUser.Email));
                    await userManager.AddClaimAsync(InitialUser, new Claim(JwtClaimTypes.Name, InitialUser.UserName));
                }
            }
        }
    }
}
