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

        public override async Task<PetModel> Update(PetModel model, CancellationToken cancellationToken)
        {
            var entityToUpdate = _mapper.Map<PetEntity>(model);

            var petEntity = await _repository.GetById(model.Id, cancellationToken);
            entityToUpdate.OwnerId = petEntity.OwnerId;

            return _mapper.Map<PetModel>(await _repository.Update(entityToUpdate, cancellationToken));
        }
    }
}
