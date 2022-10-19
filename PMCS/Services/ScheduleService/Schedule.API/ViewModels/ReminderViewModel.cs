using Schedule.Domain.Enums;

namespace Schedule.API.ViewModels
{
    public record ReminderViewModel(
        string Id,
        DateTime TriggerDateTime,
        DateTime LastModified,
        string Description,
        string NotificationMessage,
        bool IsTriggered,
        int RemainingTimePercentageBeforeTriggering,
        NotificationType NotificationType,
        ActionToRemindType ActionToRemindType,
        ExecutionStatus Status);
}
