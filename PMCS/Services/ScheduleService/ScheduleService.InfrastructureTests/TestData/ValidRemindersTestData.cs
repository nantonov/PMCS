using Schedule.Domain.Entities;
using Schedule.Domain.Enums;
using System.Collections;

namespace ScheduleService.InfrastructureTests.TestData
{
    public class ValidRemindersTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Reminder(DateTime.UtcNow.AddYears(1), 1, 1, "Jackie has to visit vet.", "test@gmail.com", NotificationType.Email,
                    ActionToRemindType.MakeVaccine)
            };
            yield return new object[]
            {
                new Reminder(DateTime.UtcNow.AddDays(1), 10, 1, "TestDescription", "test@gmail.com", NotificationType.PersonalAccount,
                    ActionToRemindType.GoForWalk)
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class TestReminders
    {
        public static List<Reminder> ValidReminders = new List<Reminder>()
        {
            new Reminder(DateTime.UtcNow.AddYears(1), 1, 1, "Jackie has to visit vet.", "test@gmail.com", NotificationType.Email,
                ActionToRemindType.MakeVaccine),
            new Reminder(DateTime.UtcNow.AddDays(1), 10, 1, "TestDescription", "test@gmail.com", NotificationType.PersonalAccount,
                ActionToRemindType.GoForWalk),
            new Reminder(DateTime.UtcNow.AddDays(1), 10, 2, "Feed Frank with meat","test@gmail.com", NotificationType.PersonalAccount,
            ActionToRemindType.FeedPet)
        };

        public static Reminder UpdatedReminder = new Reminder((DateTime.UtcNow.AddDays(7)), 1, 1,
            "Jackie has to have a meal.", "test@gmail.com", NotificationType.PersonalAccount, ActionToRemindType.FeedPet);

        public const int TestUserId = 1;
        public static int UserRemindersCount => ValidReminders.Count(x => x.UserId == TestUserId);
    }
}
