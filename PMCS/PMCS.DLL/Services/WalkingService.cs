using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.DLL.Services
{
    public class WalkingService : GenericService<WalkingModel, WalkingEntity>, IWalkingService
    {
        private readonly IPetService _petService;

        public WalkingService(IWalkingRepository repository, IMapper mapper, IPetService petService) : base(repository, mapper)
        {
            _petService = petService;
        }
        public override async Task<WalkingModel> Update(WalkingModel model, CancellationToken cancellationToken)
        {
            if (!await IsModelExists(model.Id, cancellationToken) || !await _petService.IsModelExists(model.PetId, cancellationToken))
                throw new ModelIsNotFoundException();

            var entity = _mapper.Map<WalkingEntity>(model);

            return _mapper.Map<WalkingModel>(await _repository.Update(entity, cancellationToken));
        }
    }
}
