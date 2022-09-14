using Schedule.Domain.Entities;
using Schedule.Domain.Enums;

namespace ScheduleService.DomainTests.TestData
{
    public static class TestValidReminderEntity
    {
        public static Reminder ValidReminder = new Reminder(DateTime.UtcNow.AddYears(1), 1, 1,
            "Jackie has to visit vet.", NotificationType.Email, ActionToRemindType.MakeVaccine);
    }
}
