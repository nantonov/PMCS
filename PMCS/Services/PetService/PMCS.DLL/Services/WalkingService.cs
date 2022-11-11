using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Exceptions;
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

            var result = await _repository.Update(entity, cancellationToken);

            return _mapper.Map<WalkingModel>(result);
        }

        public async Task<IEnumerable<WalkingModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByPredicate(x => x.Pet.OwnerId == ownerId, cancellationToken);

            var result = _mapper.Map<IEnumerable<WalkingModel>>(entities);

            return result;
        }
    }
}
