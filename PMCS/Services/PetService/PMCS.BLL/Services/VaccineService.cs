using AutoMapper;
using PMCS.BLL.Exceptions;
using PMCS.BLL.Interfaces.Services;
using PMCS.BLL.Models;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;

namespace PMCS.BLL.Services
{
    public class VaccineService : GenericService<VaccineModel, VaccineEntity>, IVaccineService
    {
        private readonly IPetService _petService;

        public VaccineService(IVaccineRepository repository, IMapper mapper, IPetService petService) : base(repository, mapper)
        {
            _petService = petService;
        }

        public override async Task<VaccineModel> Update(VaccineModel model, CancellationToken cancellationToken)
        {
            if (!await IsModelExists(model.Id, cancellationToken) || !await _petService.IsModelExists(model.PetId, cancellationToken))
                throw new ModelIsNotFoundException();

            var entity = _mapper.Map<VaccineEntity>(model);

            var result = await _repository.Update(entity, cancellationToken);

            return _mapper.Map<VaccineModel>(result);
        }

        public async Task<IEnumerable<VaccineModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByPredicate(x => x.Pet.OwnerId == ownerId, cancellationToken);

            var result = _mapper.Map<IEnumerable<VaccineModel>>(entities);

            return result;
        }
    }
}
