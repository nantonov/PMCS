using Notifications.BLL.Models.DTOs;

namespace Notifications.BLL.Interfaces.Services
{
    public interface INotificationService<T> where T : Notification
    {
        public Task SendNotification(T notification);
    }
}
