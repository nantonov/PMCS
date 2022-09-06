using Schedule.Domain.Enums;

namespace Schedule.API.Requests
{
    public record PutReminderRequest(
        int Id,
        DateTime TriggerDateTime,
        string NotificationMessage,
        NotificationType NotificationType,
        ActionToRemindType ActionToRemindType);
}
