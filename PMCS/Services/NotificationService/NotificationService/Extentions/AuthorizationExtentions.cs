using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Notifications.API.Authentication;
using Notifications.BLL.SignalR.Configuration;

namespace Notifications.API.Extentions
{
    public static class AuthorizationExtentions
    {
        public static void ConfigureAuthenticationScheme(this IServiceCollection services)
        {
            services.AddAuthentication("Custom")
                .AddScheme<CustomAuthenticationOptions, CustomAuthenticationHandler>("Custom", null);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = "https://localhost:5001/";
                options.RequireHttpsMetadata = false;
                options.Audience = "NotificationsAPI";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            (path.StartsWithSegments(NotificationHubConfiguration.HubURL)))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
