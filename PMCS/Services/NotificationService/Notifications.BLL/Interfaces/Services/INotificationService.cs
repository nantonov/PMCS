using Notifications.BLL.Models.DTOs;

namespace Notifications.BLL.Interfaces.Services
{
    public interface INotificationService<in T> where T : Notification
    {
        public Task SendNotification(T notification);
    }
}
