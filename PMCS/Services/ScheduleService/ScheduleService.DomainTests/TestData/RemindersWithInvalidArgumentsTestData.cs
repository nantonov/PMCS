using Schedule.Domain.Enums;
using System.Collections;

namespace ScheduleService.DomainTests.TestData
{
    public class RemindersWithInvalidArgumentsTestData : IEnumerable<object[]>
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
                    ActionToRemindType = ActionToRemindType.MakeVaccine

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
                    ActionToRemindType = ActionToRemindType.MakeVaccine
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
                    ActionToRemindType = ActionToRemindType.MakeVaccine
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
                    ActionToRemindType = ActionToRemindType.MakeVaccine
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
