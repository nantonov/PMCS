namespace Schedule.API.Requests
{
    public record PostReminderRequest(
        DateTime TriggerDateTime,
        int PetId,
        string NotificationMessage,
        string NotificationType,
        string ActionToRemindType);
}
