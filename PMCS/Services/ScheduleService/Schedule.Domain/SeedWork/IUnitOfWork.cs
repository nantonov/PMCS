namespace Schedule.Domain.SeedWork;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}
