using Microsoft.EntityFrameworkCore;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PMCS.DAL.Repositories
{
    public class MealRepository : GenericRepository<MealEntity>, IMealRepository
    {
        public MealRepository(AppContext context) : base(context) { }

        public override async Task<IEnumerable<MealEntity>> Get(CancellationToken cancellationToken)
        {
            return await _dbSet.Include(x => x.Pet).ToListAsync(cancellationToken);
        }

        public override async Task<MealEntity> GetById(int id, CancellationToken cancellationToken)
        {
            return await Query.Include(x => x.Pet).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public override async Task<IEnumerable<MealEntity>> GetByPredicate(Expression<Func<MealEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var entities = await Query.Where(predicate).Include(x => x.Pet).ToListAsync(cancellationToken);

            return entities;
        }
    }
}
