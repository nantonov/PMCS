using PMCS.DAL.Entities;

namespace PMCS.DAL.Interfaces.Repositories
{
    public interface IPetRepository : IGenericRepository<PetEntity>
    {
        Task<IEnumerable<PetEntity>> GetByOwnerId(int ownerId, CancellationToken cancellationToken);
    }
}
