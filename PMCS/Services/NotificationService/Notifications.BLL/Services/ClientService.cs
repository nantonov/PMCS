using Microsoft.AspNetCore.SignalR;
using Notifications.BLL.Interfaces.Services;
using Notifications.BLL.Models.DTOs;
using Notifications.BLL.Models.Payloads;
using Notifications.BLL.Resources.Constants;
using Notifications.BLL.SignalR.Hubs;

namespace Notifications.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public ClientService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotification(ClientNotification notification)
        {
            var payload = MapNotificationToPayload(notification);

            await _hubContext.Clients.User(notification.UserId).SendAsync(HubConfiguration.HandlerMethod, payload);
        }

        private ClientNotificationPayload MapNotificationToPayload(ClientNotification notification)
        {
            return new ClientNotificationPayload()
            {
                Message = notification.Message
            };
        }
    }
}
