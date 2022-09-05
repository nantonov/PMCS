﻿using Schedule.Domain.Entities;
using Schedule.Domain.SeedWork;

namespace Schedule.Domain.Repositories
{
    public interface IReminderRepository : IRepository<Reminder>
    {
        Task<IReadOnlyList<Reminder>> GetAll(CancellationToken cancellationToken);
        Task<IReadOnlyList<Reminder>> GetUserReminders(int userId, CancellationToken cancellationToken);
        Task<Reminder> GetById(int id, CancellationToken cancellationToken);
        Task<Reminder> Insert(Reminder reminder, CancellationToken cancellationToken);
        Task<Reminder> Update(Reminder reminder, CancellationToken cancellationToken);
        Task<Reminder> Delete(Reminder reminder, CancellationToken cancellationToken);
    }
}
