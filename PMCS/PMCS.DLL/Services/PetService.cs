using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.DLL.Services
{
    public class PetService : GenericService<PetModel, PetEntity>, IPetService
    {
        public PetService(IPetRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
