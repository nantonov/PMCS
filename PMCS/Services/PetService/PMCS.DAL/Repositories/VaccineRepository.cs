using Microsoft.EntityFrameworkCore;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PMCS.DAL.Repositories
{
    public class VaccineRepository : GenericRepository<VaccineEntity>, IVaccineRepository
    {
        public VaccineRepository(AppContext context) : base(context) { }

        public override async Task<IEnumerable<VaccineEntity>> Get(CancellationToken cancellationToken)
        {
            return await _dbSet.Include(x => x.Pet).ToListAsync(cancellationToken);
        }

        public override async Task<VaccineEntity> GetById(int id, CancellationToken cancellationToken)
        {
            return await Query.Include(x => x.Pet).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public override async Task<IEnumerable<VaccineEntity>> GetByPredicate(Expression<Func<VaccineEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var entities = await Query.Where(predicate).Include(x => x.Pet).ToListAsync(cancellationToken);

            return entities;
        }
    }
}
