using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Schedule.Domain.Entities;
using Schedule.Domain.Repositories;
using Schedule.Infrastructure;
using Schedule.Infrastructure.Repositories;
using ScheduleService.InfrastructureTests.TestData;

namespace ScheduleService.InfrastructureTests
{
    public class ReminderRepositoryIntegrationTests : IDisposable
    {
        private readonly Mock<IMediator> _mediatorMock = new();
        private readonly IReminderRepository _repository;
        private ScheduleDbContext _context;

        public ReminderRepositoryIntegrationTests()
        {
            _context = new ScheduleDbContext(new DbContextOptionsBuilder<ScheduleDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options, _mediatorMock.Object);
            _repository = new ReminderRepository(_context);
        }

        [Fact]
        public async Task GetAll_RemindersDoNotExist_ReturnsEmptyList()
        {
            var result = await _repository.GetAll(default);

            Assert.Empty(result);
        }

        [Fact]
        public async Task Get_NoReminderAreTriggered_ReturnsEmptyListOfTriggeredReminders()
        {
            await InitializeDatabaseWithValidRemindersAsync();

            var result = await _repository.Get(x => x.IsTriggered, default);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAll_RemindersExist_ReturnsReminders()
        {
            await InitializeDatabaseWithValidRemindersAsync();
            var result = await _repository.GetAll(default);

            var actualCount = result.Count();

            Assert.NotNull(result);
            Assert.Equal(TestReminders.ValidReminders.Count, actualCount);
        }

        [Fact]
        public async Task GetById_ReminderExists_ReturnsReminder()
        {
            await InitializeDatabaseWithValidRemindersAsync();
            var result = await _repository.GetById(1, default);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetUserReminders_RemindersExist_ReturnsUserReminders()
        {
            await InitializeDatabaseWithValidRemindersAsync();
            var result = await _repository.GetUserReminders(TestReminders.TestUserId, default);

            var actualCount = result.Count();

            Assert.NotNull(result);
            Assert.Equal(TestReminders.UserRemindersCount, actualCount);
        }

        [Theory]
        [ClassData(typeof(ValidRemindersTestData))]
        public async Task Insert_ValidData_InsertsReminder(Reminder reminder)
        {
            var entity = await _repository.Insert(reminder, default);

            Assert.NotNull(entity);
        }

        [Fact]
        public async Task Delete_ValidData_DeletesReminder()
        {
            await InitializeDatabaseWithValidRemindersAsync();
            var reminderToDelete = TestReminders.ValidReminders.FirstOrDefault();

            var result = await _repository.Delete(reminderToDelete, default);

            Assert.Equal(reminderToDelete.TriggerDateTime, result.TriggerDateTime);
        }

        [Fact]
        public async Task Update_ReminderExists_UpdatesReminder()
        {
            await InitializeDatabaseWithValidRemindersAsync();
            var reminderToUpdate = TestReminders.ValidReminders.FirstOrDefault();

            reminderToUpdate.Update(TestReminders.UpdatedReminder.TriggerDateTime, TestReminders.UpdatedReminder.NotificationMessage,
                TestReminders.UpdatedReminder.NotificationType, TestReminders.UpdatedReminder.ActionToRemindType);

            var result = await _repository.Update(reminderToUpdate, default);

            Assert.Equal(result.TriggerDateTime, TestReminders.UpdatedReminder.TriggerDateTime);
            Assert.Equal(result.NotificationType, TestReminders.UpdatedReminder.NotificationType);
            Assert.Equal(result.ActionToRemindType, TestReminders.UpdatedReminder.ActionToRemindType);
            Assert.Equal(result.NotificationMessage, TestReminders.UpdatedReminder.NotificationMessage);
        }

        private async Task<List<Reminder>> InitializeDatabaseWithValidRemindersAsync()
        {
            foreach (var reminder in TestReminders.ValidReminders)
            {
                await _repository.Insert(reminder, default);
            }

            return TestReminders.ValidReminders;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}