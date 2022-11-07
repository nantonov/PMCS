using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Entities;
using Schedule.Domain.Repositories;
using System.Linq.Expressions;

namespace Schedule.Infrastructure.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly ScheduleDbContext _context;

        public ReminderRepository(ScheduleDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Reminder>> Get(Expression<Func<Reminder, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Reminders.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Reminder>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _context.Reminders.AsNoTracking().ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IReadOnlyList<Reminder>> GetUserReminders(int userId, CancellationToken cancellationToken)
        {
            var result = await _context.Reminders.Where(x => x.UserId == userId).ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Reminder?> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _context.Reminders.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return result;
        }

        public async Task<Reminder> Insert(Reminder reminder, CancellationToken cancellationToken)
        {
            _context.Entry(reminder).State = EntityState.Added;
            await _context.SaveEntitiesAsync(cancellationToken);

            return reminder;
        }

        public async Task<Reminder> Update(Reminder reminder, CancellationToken cancellationToken)
        {
            _context.Entry(reminder).State = EntityState.Modified;
            await _context.SaveEntitiesAsync(cancellationToken);

            return reminder;
        }

        public async Task<Reminder> Delete(Reminder reminder, CancellationToken cancellationToken)
        {
            _context.Entry(reminder).State = EntityState.Deleted;
            await _context.SaveEntitiesAsync(cancellationToken);

            return reminder;
        }

        public async Task<IReadOnlyList<Reminder>> DeleteRange(IReadOnlyList<Reminder> reminders, CancellationToken cancellationToken)
        {
            foreach (var reminder in reminders)
            {
                _context.Entry(reminder).State = EntityState.Deleted;
            }

            await _context.SaveEntitiesAsync(cancellationToken);

            return reminders;
        }
    }
}
