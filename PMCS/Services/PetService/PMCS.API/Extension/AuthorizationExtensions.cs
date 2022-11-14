using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace PMCS.API.Extension
{
    public static class AuthorizationExtensions
    {
        public static void RegisterAuthorizationServices(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = "https://localhost:5001/";
                options.RequireHttpsMetadata = false;
                options.Audience = "PetAPI";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                };
            });

            services.AddAuthorization();
        }
    }
}
