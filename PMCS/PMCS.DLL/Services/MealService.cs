using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.DLL.Services
{
    public class MealService : GenericService<MealModel, MealEntity>, IMealService
    {
        private readonly IPetService _petService;
        public MealService(IMealRepository repository, IMapper mapper, IPetService petService) : base(repository, mapper)
        {
            _petService = petService;
        }

        public override async Task<MealModel> Update(MealModel model, CancellationToken cancellationToken)
        {
            if (!await IsModelExists(model.Id, cancellationToken) || !await _petService.IsModelExists(model.PetId, cancellationToken))
                throw new ModelIsNotFoundException();

            var entity = _mapper.Map<MealEntity>(model);

            return _mapper.Map<MealModel>(await _repository.Update(entity, cancellationToken));
        }
    }
}
