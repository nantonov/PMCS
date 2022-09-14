using Schedule.Domain.Enums;
using System.Collections;

namespace ScheduleService.DomainTests.TestData
{
    public class RemindersWithInvalidTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new TestReminder
                {
                    TriggerDateTime = DateTime.UtcNow.AddYears(1),
                    NotificationMessage = "Jackie has to visit vet.",
                    NotificationType = NotificationType.Email,
                    ActionToRemindType = ActionToRemindType.MakeVaccine,
                    UserEmail = "test@gmail.com"
                }
            };
            yield return new object[]
            {
                new TestReminder
                {
                    TriggerDateTime = DateTime.UtcNow.AddYears(1),
                    PetId = 1,
                    NotificationMessage = "Jackie has to visit vet.",
                    NotificationType = NotificationType.Email,
                    ActionToRemindType = ActionToRemindType.MakeVaccine,
                    UserEmail = "test@gmail.com"
                }
            };
            yield return new object[]
            {
                new TestReminder
                {
                    TriggerDateTime = DateTime.UtcNow.AddYears(1),
                    UserId = 1,
                    NotificationMessage = "Jackie has to visit vet.",
                    NotificationType = NotificationType.Email,
                    ActionToRemindType = ActionToRemindType.MakeVaccine,
                    UserEmail = "test@gmail.com"
                }
            };
            yield return new object[]
            {
                new TestReminder
                {
                    TriggerDateTime = DateTime.UtcNow.AddYears(1),
                    PetId = 1,
                    UserId = 1,
                    NotificationMessage = String.Empty,
                    NotificationType = NotificationType.Email,
                    ActionToRemindType = ActionToRemindType.MakeVaccine,
                    UserEmail = "test@gmail.com"
                }
            };
            yield return new object[]
            {
                new TestReminder
                {
                    TriggerDateTime = DateTime.UtcNow.AddYears(1),
                    PetId = 1,
                    UserId = 1,
                    NotificationMessage = "message",
                    NotificationType = NotificationType.Email,
                    ActionToRemindType = ActionToRemindType.MakeVaccine,
                    UserEmail = "not email"
                }
            };
            yield return new object[]
            {
                new TestReminder
                {
                    TriggerDateTime = DateTime.UtcNow.AddYears(1),
                    PetId = 1,
                    UserId = 1,
                    NotificationMessage = "message",
                    NotificationType = NotificationType.Email,
                    ActionToRemindType = ActionToRemindType.MakeVaccine,
                    UserEmail = "useremail.com"
                }
            };
            yield return new object[] { new TestReminder
            {
                TriggerDateTime = new DateTime(2022, 1, 1),
                PetId = 1,
                UserId = 1,
                NotificationMessage = "Jackie has to visit vet.",
                NotificationType = NotificationType.Email,
                ActionToRemindType = ActionToRemindType.MakeVaccine,
                UserEmail = "test@gmail.com"
            }};
            yield return new object[] { new TestReminder
            {
                TriggerDateTime = DateTime.UtcNow.AddYears(1),
                PetId = 1,
                UserId = 1,
                NotificationMessage = "Reminder",
                NotificationType = NotificationType.Email,
                ActionToRemindType = (ActionToRemindType)10,
                UserEmail = "test@gmail.com"
            }};
            yield return new object[] { new TestReminder
            {
                TriggerDateTime = new DateTime(2022, 1, 1),
                PetId = 1,
                UserId = 1,
                NotificationMessage = "Make vaccine",
                NotificationType = (NotificationType)14,
                ActionToRemindType = ActionToRemindType.MakeVaccine,
                UserEmail = "test@gmail.com"
            }};
            yield return new object[] { new TestReminder
            {
                TriggerDateTime = DateTime.UtcNow,
                PetId = 1,
                UserId = 1,
                NotificationMessage = "Jackie has to visit vet.",
                NotificationType = NotificationType.Email,
                ActionToRemindType = ActionToRemindType.MakeVaccine,
                UserEmail = "test@gmail.com"
            }};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
