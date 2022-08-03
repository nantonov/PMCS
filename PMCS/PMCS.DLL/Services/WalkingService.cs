using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.DLL.Services
{
    public class WalkingService : GenericService<WalkingModel, WalkingEntity>, IWalkingService
    {
        public WalkingService(IWalkingRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
