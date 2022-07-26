﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Notifications.BLL.Interfaces.Services;
using Notifications.BLL.Services;
using Notifications.BLL.SignalR.Connections;

namespace Notifications.BLL.DI
{
    public static class BusinessLogicRegistration
    {
        public static void RegisterBusinessLogicDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IUserIdProvider, UserConnectionProvider>();
        }
    }
}
