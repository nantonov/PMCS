using Schedule.Domain.Enums;

namespace ScheduleService.DomainTests.TestData
{
    public class TestReminder
    {
        public int PetId { get; set; }
        public int UserId { get; set; }
        public DateTime LastModified { get; set; }
        public string Description { get; set; }
        public string NotificationMessage { get; set; }
        public bool IsTriggered { get; set; }
        public NotificationType NotificationType { get; set; }
        public ActionToRemindType ActionToRemindType { get; set; }
        public ExecutionStatus Status { get; set; }
        public string UserEmail { get; set; }

        public DateTime TriggerDateTime { get; set; }
    }
}
