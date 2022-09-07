using Schedule.Domain.Enums;

namespace Schedule.API.Requests
{
    public record PostReminderRequest(
        DateTime TriggerDateTime,
        int PetId,
        string NotificationMessage,
        NotificationType NotificationType,
        ActionToRemindType ActionToRemindType);
}
