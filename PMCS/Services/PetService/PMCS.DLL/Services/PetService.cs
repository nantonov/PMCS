using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Exceptions;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.DLL.Services
{
    public class PetService : GenericService<PetModel, PetEntity>, IPetService
    {
        private readonly IOwnerService _ownerService;
        public PetService(IPetRepository repository, IMapper mapper, IOwnerService ownerService) : base(repository, mapper)
        {
            _ownerService = ownerService;
        }

        public override async Task<PetModel> Update(PetModel model, CancellationToken cancellationToken)
        {
            if (!await IsModelExists(model.Id, cancellationToken) || !await _ownerService.IsModelExists(model.OwnerId, cancellationToken))
                throw new ModelIsNotFoundException();

            var entity = _mapper.Map<PetEntity>(model);

            return _mapper.Map<PetModel>(await _repository.Update(entity, cancellationToken));
        }
    }
}
