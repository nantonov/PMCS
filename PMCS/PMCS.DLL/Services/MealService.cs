using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.DLL.Services
{
    public class MealService : GenericService<MealModel, MealEntity>, IMealService
    {
        public MealService(IMealRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
