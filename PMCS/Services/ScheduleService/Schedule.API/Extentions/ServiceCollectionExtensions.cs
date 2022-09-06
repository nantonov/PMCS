using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Schedule.Application.Configuration;

namespace Schedule.API.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureAuthenticationScheme(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = AuthConfiguration.Authority;
                options.RequireHttpsMetadata = AuthConfiguration.RequireHttpsMetadata;
                options.Audience = AuthConfiguration.Audience;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = AuthConfiguration.ValidateAudience,
                };
            });
        }
    }
}
