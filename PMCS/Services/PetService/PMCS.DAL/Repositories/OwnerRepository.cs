using Microsoft.EntityFrameworkCore;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;

namespace PMCS.DAL.Repositories
{
    public class OwnerRepository : GenericRepository<OwnerEntity>, IOwnerRepository
    {
        public OwnerRepository(AppContext context) : base(context) { }

        public override async Task<IEnumerable<OwnerEntity>> Get(CancellationToken cancellationToken)
        {
            return await _dbSet.Include(x => x.Pets).ToListAsync(cancellationToken);
        }

        public override async Task<OwnerEntity> GetById(int id, CancellationToken cancellationToken)
        {
            return await Query.Include(x => x.Pets).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
