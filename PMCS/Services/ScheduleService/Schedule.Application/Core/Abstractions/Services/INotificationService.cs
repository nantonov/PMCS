using Schedule.Application.Core.Abstractions.Models;
using Schedule.Domain.Entities;

namespace Schedule.Application.Core.Abstractions.Services
{
    public interface INotificationService
    {
        Task<INotification> Notify(Reminder reminder);
    }
}
