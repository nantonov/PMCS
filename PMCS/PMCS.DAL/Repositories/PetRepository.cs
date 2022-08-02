using Microsoft.EntityFrameworkCore;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;

namespace PMCS.DAL.Repositories
{
    public class PetRepository : GenericRepository<PetEntity>, IPetRepository
    {
        public PetRepository(AppContext context) : base(context) { }
        public override async Task<IEnumerable<PetEntity>> Get(CancellationToken cancellationToken)
        {
            return await _dbSet.Include(x => x.Vaccines).
                                Include(x=>x.Walkings).
                                Include(x=>x.Meals).
                                Include(x=>x.Owner).
                                ToListAsync(cancellationToken);
        }

        public override async Task<PetEntity> GetById(int id, CancellationToken cancellationToken)
        {
            return await Query.AsNoTracking().
                               Include(x => x.Vaccines).
                               Include(x => x.Walkings).
                               Include(x => x.Meals).
                               Include(x => x.Owner).
                               FirstOrDefaultAsync(x=>x.Id==id, cancellationToken);
        }
    }
}
