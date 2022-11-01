using PMCS.DAL.Interfaces.Entities;
using System.Linq.Expressions;

namespace PMCS.DAL.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : IHasIdEntity
    {
        Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> Get(CancellationToken cancellationToken);
        Task<TEntity> GetById(int id, CancellationToken cancellationToken);
        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> Delete(int id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> InsertRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetByPredicate(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    }
}
