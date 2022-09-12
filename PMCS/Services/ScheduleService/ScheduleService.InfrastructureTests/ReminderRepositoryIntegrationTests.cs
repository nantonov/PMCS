using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Schedule.Domain.Entities;
using Schedule.Domain.Enums;
using Schedule.Domain.Repositories;
using Schedule.Infrastructure;
using Schedule.Infrastructure.Repositories;

namespace ScheduleService.InfrastructureTests
{
    public class ReminderRepositoryIntegrationTests : IDisposable
    {
        private readonly Mock<IMediator> _mediatorMock = new Mock<IMediator>();
        private readonly IReminderRepository _repository;
        private ScheduleDbContext _context;

        public ReminderRepositoryIntegrationTests()
        {
            _context = new ScheduleDbContext(new DbContextOptionsBuilder<ScheduleDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options, _mediatorMock.Object);
            _repository = new ReminderRepository(_context);
        }

        [Fact]
        public async Task Insert_ValidData_InsertsReminder()
        {
            var reminder = new Reminder(DateTime.UtcNow.AddDays(7), 1, 1, "Hello", NotificationType.Email,
                ActionToRemindType.GoForWalk);

            var entity = await _repository.Insert(reminder, default);

            Assert.NotNull(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}