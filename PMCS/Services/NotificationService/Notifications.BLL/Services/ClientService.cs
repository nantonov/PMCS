﻿using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Notifications.BLL.Interfaces.Services;
using Notifications.BLL.Models.DTOs;
using Notifications.BLL.Models.Payloads;
using Notifications.BLL.SignalR.Configuration;
using Notifications.BLL.SignalR.Hubs;

namespace Notifications.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IMapper _mapper;

        public ClientService(IHubContext<NotificationHub> hubContext, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(hubContext);
            ArgumentNullException.ThrowIfNull(mapper);

            _hubContext = hubContext;
            _mapper = mapper;
        }

        public async Task SendNotification(ClientNotification notification)
        {
            var payload = _mapper.Map<ClientNotificationPayload>(notification);

            await _hubContext.Clients.User(notification.UserId).SendAsync(NotificationHubConfiguration.HandlingMethodURL, payload.Message);
        }
    }
}
