using Microsoft.EntityFrameworkCore;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;

namespace PMCS.DAL.Repositories
{
    public class WalkingRepository : GenericRepository<WalkingEntity>, IWalkingRepository
    {
        public WalkingRepository(AppContext context) : base(context) { }
        public override async Task<IEnumerable<WalkingEntity>> Get(CancellationToken cancellationToken)
        {
            return await _dbSet.Include(x => x.Pet).ToListAsync(cancellationToken);
        }

        public override async Task<WalkingEntity> GetById(int id, CancellationToken cancellationToken)
        {
            return await Query.Include(x => x.Pet).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
