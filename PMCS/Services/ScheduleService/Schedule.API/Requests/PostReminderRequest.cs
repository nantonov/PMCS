using Schedule.Domain.Enums;

namespace Schedule.API.Requests
{
    public record PostReminderRequest(
        DateTime TriggerDateTime,
        int PetId,
        int UserId,
        string NotificationMessage,
        NotificationType NotificationType,
        ActionToRemindType ActionToRemindType);
}
