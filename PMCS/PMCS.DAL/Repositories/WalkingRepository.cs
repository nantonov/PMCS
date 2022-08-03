using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;

namespace PMCS.DAL.Repositories
{
    public class WalkingRepository : GenericRepository<WalkingEntity>, IWalkingRepository
    {
        public WalkingRepository (AppContext context) : base(context) { }
    }
}
