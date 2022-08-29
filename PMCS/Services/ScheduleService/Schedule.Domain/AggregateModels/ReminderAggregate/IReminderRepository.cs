using Schedule.Domain.SeedWork;

namespace Schedule.Domain.AggregateModels.ReminderAggregate
{
    public interface IReminderRepository : IRepository<Reminder>
    {
        Task<IReadOnlyList<Reminder>> GetAll(CancellationToken cancellationToken);
        Task<IReadOnlyList<Reminder>> GetById(int ownerId, CancellationToken cancellationToken);
        Task<Reminder> Insert(Reminder reminder, CancellationToken cancellationToken);
        Task<Reminder> Update(Reminder reminder, CancellationToken cancellationToken);
        Task<Reminder> Delete(Reminder reminder, CancellationToken cancellationToken);
    }
}
