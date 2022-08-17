using Notifications.BLL.Models.Payloads;

namespace Notifications.BLL.Interfaces.Services
{
    public interface IEmailService : INotificationService<EmailNotificationPayload>
    {
    }
}
