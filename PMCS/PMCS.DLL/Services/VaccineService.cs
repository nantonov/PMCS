using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Exceptions;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.DLL.Services
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

            return _mapper.Map<VaccineModel>(await _repository.Update(entity, cancellationToken));
        }
    }
}
