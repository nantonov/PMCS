using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Notifications.BLL.SignalR.Connections
{
    public class UserConnectionProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            return connection.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
