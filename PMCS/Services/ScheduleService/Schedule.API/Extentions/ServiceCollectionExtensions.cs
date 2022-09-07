using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, config =>
            {
                config.Authority = AuthConfiguration.Authority;
                config.ClientId = AuthConfiguration.SwaggerClientId;
                config.ClientSecret = AuthConfiguration.ClientSecret;
                config.SaveTokens = true;
                config.ResponseType = "id_token";
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = AuthConfiguration.ValidateAudience
                };

                config.Scope.Add(AuthConfiguration.ScheduleScope);
                config.Scope.Add("email");
                config.Scope.Add("openid");
                config.Scope.Add("profile");

                config.GetClaimsFromUserInfoEndpoint = true;
                config.ClaimActions.MapAll();
            });
        }
    }
}
