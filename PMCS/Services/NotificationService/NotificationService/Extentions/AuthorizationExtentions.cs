﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Notifications.API.Authentication;

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
            });
        }
    }
}
