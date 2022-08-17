using Notifications.BLL.Models.Payloads;

namespace Notifications.BLL.Interfaces.Services
{
    public interface INotificationService<in T> where T : NotificationPayload
    {
        public Task SendNotification(T payload);
    }
}
