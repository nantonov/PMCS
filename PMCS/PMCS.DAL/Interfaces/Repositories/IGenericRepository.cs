using PMCS.DAL.Interfaces.Entities;

namespace PMCS.DAL.Interfaces.Repositories
{
    public interface IGenericRepository <TEntity> where TEntity : IHasIdEntity
    {
        Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> Get(CancellationToken cancellationToken);
        Task<TEntity> GetById(int id, CancellationToken cancellationToken);
        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> Delete(int id, CancellationToken cancellationToken);
    }
}
