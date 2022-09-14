using Schedule.Domain.Enums;
using System.Collections;

namespace ScheduleService.DomainTests.TestData
{
    public class RemindersWithInvalidTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> InvalidReminders = new List<object[]>
        {
            new object[] { new TestReminder
            {
                TriggerDateTime = DateTime.UtcNow.AddYears(1),
                NotificationMessage = "Jackie has to visit vet.",
                NotificationType = NotificationType.Email,
                ActionToRemindType = ActionToRemindType.MakeVaccine,
                UserEmail = "test@gmail.com"
            }},
            new object[] {  new TestReminder
            {
                TriggerDateTime = DateTime.UtcNow.AddYears(1),
                PetId = 1,
                NotificationMessage = "Jackie has to visit vet.",
                NotificationType = NotificationType.Email,
                ActionToRemindType = ActionToRemindType.MakeVaccine,
                UserEmail = "test@gmail.com"
            }},
            new object[] { new TestReminder
            {
                TriggerDateTime = DateTime.UtcNow.AddYears(1),
                UserId = 1,
                NotificationMessage = "Jackie has to visit vet.",
                NotificationType = NotificationType.Email,
                ActionToRemindType = ActionToRemindType.MakeVaccine,
                UserEmail = "test@gmail.com"
            }},
            new object[] { new TestReminder
            {
                TriggerDateTime = DateTime.UtcNow,
                PetId = 1,
                UserId = 1,
                NotificationMessage = "Jackie has to visit vet.",
                NotificationType = NotificationType.Email,
                ActionToRemindType = ActionToRemindType.MakeVaccine,
                UserEmail = "test@gmail.com"
            }},
            new object[] { new TestReminder
            {
                TriggerDateTime = new DateTime(2022, 1, 1),
                PetId = 1,
                UserId = 1,
                NotificationMessage = "Make vaccine",
                NotificationType = (NotificationType)14,
                ActionToRemindType = ActionToRemindType.MakeVaccine,
                UserEmail = "test@gmail.com"
            }},
            new object[] { new TestReminder
            {
                TriggerDateTime = DateTime.UtcNow.AddYears(1),
                PetId = 1,
                UserId = 1,
                NotificationMessage = "Reminder",
                NotificationType = NotificationType.Email,
                ActionToRemindType = (ActionToRemindType)10,
                UserEmail = "test@gmail.com"
            }},
            new object[] { new TestReminder
            {
                TriggerDateTime = new DateTime(2022, 1, 1),
                PetId = 1,
                UserId = 1,
                NotificationMessage = "Jackie has to visit vet.",
                NotificationType = NotificationType.Email,
                ActionToRemindType = ActionToRemindType.MakeVaccine,
                UserEmail = "test@gmail.com"
            }},
            new object[] { new TestReminder
            {
                TriggerDateTime = DateTime.UtcNow.AddYears(1),
                PetId = 1,
                UserId = 1,
                NotificationMessage = "message",
                NotificationType = NotificationType.Email,
                ActionToRemindType = ActionToRemindType.MakeVaccine,
                UserEmail = "useremail.com"
            }}
    };

        public IEnumerator<object[]> GetEnumerator() => InvalidReminders.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
