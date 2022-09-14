using Schedule.Domain.Core.Exceptions;
using Schedule.Domain.Entities;
using Schedule.Domain.Enums;
using ScheduleService.DomainTests.TestData;
using static ScheduleService.DomainTests.TestData.TestValidReminderEntity;


namespace ScheduleService.DomainTests
{
    public class ReminerEntityTests
    {
        [Fact]
        public void CallConstructor_ValidData_CreatesNewReminder()
        {
            var reminder = new Reminder(ValidReminder.TriggerDateTime, ValidReminder.PetId, ValidReminder.UserId,
                ValidReminder.NotificationMessage, ValidReminder.NotificationType, ValidReminder.ActionToRemindType);

            Assert.NotNull(reminder);
            Assert.Equal(ValidReminder.TriggerDateTime, reminder.TriggerDateTime);
        }

        [Theory]
        [ClassData(typeof(RemindersWithInvalidDomainLogicTestData))]
        public void CallConstructor_InvalidDomainLogicData_ThrowsScheduleDomainException(TestReminder reminder)
        {
            Assert.Throws<ScheduleDomainException>(() => new Reminder(reminder.TriggerDateTime, reminder.PetId, reminder.UserId,
                reminder.NotificationMessage, reminder.NotificationType, reminder.ActionToRemindType));
        }

        [Theory]
        [ClassData(typeof(RemindersWithInvalidArgumentsTestData))]
        public void CallConstructor_InvalidArguments_ThrowsArgumentException(TestReminder reminder)
        {
            Assert.Throws<ArgumentException>(() => new Reminder(reminder.TriggerDateTime, reminder.PetId, reminder.UserId,
                reminder.NotificationMessage, reminder.NotificationType, reminder.ActionToRemindType));
        }

        [Fact]
        public void SetStatusAsDone_ValidData_SetsStatusAsDone()
        {
            var reminder = ValidReminder;

            var lastModified = reminder.LastModified;
            reminder.SetStatusAsDone();

            Assert.Equal(ExecutionStatus.Done, reminder.Status);
            Assert.NotEqual(lastModified, reminder.LastModified);
        }

        [Fact]
        public void ResetStatus_ValidData_ResetsStatus()
        {
            var reminder = ValidReminder;

            var lastModified = reminder.LastModified;
            reminder.SetStatusAsDone();

            Assert.Equal(ExecutionStatus.Done, reminder.Status);
            Assert.NotEqual(lastModified, reminder.LastModified);
        }

        [Fact]
        public void Triggered_TriggerDateTameIsLaterThanNow_ThrowsScheduleDomainException()
        {
            var reminder = ValidReminder;

            Assert.Throws<ScheduleDomainException>(() => reminder.Triggered());
        }
    }
}