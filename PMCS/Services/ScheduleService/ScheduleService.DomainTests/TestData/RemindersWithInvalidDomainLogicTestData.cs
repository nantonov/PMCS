using Schedule.Domain.Enums;
using System.Collections;

namespace ScheduleService.DomainTests.TestData
{
    public class RemindersWithInvalidDomainLogicTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new TestReminder
            {
                TriggerDateTime = new DateTime(2022, 1, 1),
                PetId = 1,
                UserId = 1,
                NotificationMessage = "Jackie has to visit vet.",
                NotificationType = NotificationType.Email,
                ActionToRemindType = ActionToRemindType.MakeVaccine
            }};
            yield return new object[] { new TestReminder
            {
                TriggerDateTime = DateTime.UtcNow.AddYears(1),
                PetId = 1,
                UserId = 1,
                NotificationMessage = "Reminder",
                NotificationType = NotificationType.Email,
                ActionToRemindType = (ActionToRemindType)10
            }};
            yield return new object[] { new TestReminder
            {
                TriggerDateTime = new DateTime(2022, 1, 1),
                PetId = 1,
                UserId = 1,
                NotificationMessage = "Make vaccine",
                NotificationType = (NotificationType)14,
                ActionToRemindType = ActionToRemindType.MakeVaccine
            }};
            yield return new object[] { new TestReminder
            {
                TriggerDateTime = DateTime.UtcNow,
                PetId = 1,
                UserId = 1,
                NotificationMessage = "Jackie has to visit vet.",
                NotificationType = NotificationType.Email,
                ActionToRemindType = ActionToRemindType.MakeVaccine
            }};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
