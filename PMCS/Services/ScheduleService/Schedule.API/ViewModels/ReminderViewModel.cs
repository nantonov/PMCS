using Schedule.Domain.Enums;

namespace Schedule.API.ViewModels
{
    public record ReminderViewModel(
        DateTime TriggerDateTime,
        DateTime LastModified,
        string Description,
        string NotificationMessage,
        bool IsTriggered,
        NotificationType NotificationType,
        ActionToRemindType ActionToRemindType,
        ExecutionStatus Status);
}
