using AutoMapper;
using PMCS.BLL;
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
        private readonly IHttpClientFactory _httpClientFactory;

        public PetService(IPetRepository repository,
            IMapper mapper,
            IOwnerService ownerService,
            IHttpClientFactory httpClientFactory) : base(repository, mapper)
        {
            _ownerService = ownerService;
            _httpClientFactory = httpClientFactory;
        }

        public override async Task<PetModel> Update(PetModel model, CancellationToken cancellationToken)
        {
            if (!await IsModelExists(model.Id, cancellationToken) || !await _ownerService.IsModelExists(model.OwnerId, cancellationToken))
                throw new ModelIsNotFoundException();

            var entity = _mapper.Map<PetEntity>(model);

            var result = await _repository.Update(entity, cancellationToken);

            return _mapper.Map<PetModel>(result);
        }

        public override async Task<PetModel> Delete(int id, CancellationToken cancellationToken)
        {
            if (!await IsModelExists(id, cancellationToken)) throw new ModelIsNotFoundException();

            var result = await _repository.Delete(id, cancellationToken);

            if (result != null)
            {
                var client = _httpClientFactory.CreateClient(ClientsConfiguration.ScheduleClientName);

                await client.DeleteAsync($"/api/Reminder/api/Pet/{id}");
            }

            return _mapper.Map<PetModel>(result);
        }
    }
}
