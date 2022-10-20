using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Notifications.BLL.SignalR.Hubs
{
    [Authorize]
    public class NotificationHub : Hub { }
}
