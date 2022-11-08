using Microsoft.EntityFrameworkCore;
using PMCS.DAL.Interfaces.Entities;
using PMCS.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PMCS.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IHasIdEntity
    {
        protected readonly AppContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        protected IQueryable<TEntity> Query => _dbSet.AsQueryable();
        public GenericRepository(AppContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetByPredicate(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var entities = await Query.Where(predicate).ToListAsync(cancellationToken);

            return entities;
        }

        public async Task<IEnumerable<TEntity>> InsertRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            await _dbSet.AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entities;
        }

        public async Task<TEntity> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await GetById(id, cancellationToken);

            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> Get(CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetById(int id, CancellationToken cancellationToken)
        {
            return await Query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
