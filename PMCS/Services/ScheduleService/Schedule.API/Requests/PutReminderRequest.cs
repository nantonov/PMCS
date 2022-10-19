namespace Schedule.API.Requests
{
    public record PutReminderRequest(
        int Id,
        DateTime TriggerDateTime,
        string NotificationMessage,
        string NotificationType,
        string ActionToRemindType);
}
