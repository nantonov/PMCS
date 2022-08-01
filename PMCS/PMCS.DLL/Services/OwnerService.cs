using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.DLL.Services
{
    public class OwnerService : GenericService<OwnerModel, OwnerEntity>, IOwnerService
    {
        public OwnerService(IOwnerRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
