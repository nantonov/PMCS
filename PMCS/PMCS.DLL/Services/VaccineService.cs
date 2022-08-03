using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.DLL.Services
{
    public class VaccineService : GenericService<VaccineModel, VaccineEntity>, IVaccineService
    {
        public VaccineService(IVaccineRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
