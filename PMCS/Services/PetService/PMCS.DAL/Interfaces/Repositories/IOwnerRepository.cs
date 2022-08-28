using PMCS.DAL.Entities;

namespace PMCS.DAL.Interfaces.Repositories
{
    public interface IOwnerRepository : IGenericRepository<OwnerEntity>
    {
        Task<OwnerEntity> GetByExternalId(int externalId, CancellationToken cancellationToken);
    }
}
