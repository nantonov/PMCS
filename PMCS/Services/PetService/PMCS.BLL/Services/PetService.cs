﻿using AutoMapper;
using PMCS.BLL.Exceptions;
using PMCS.BLL.Interfaces.Services;
using PMCS.BLL.Models;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;

namespace PMCS.BLL.Services
{
    public class PetService : GenericService<PetModel, PetEntity>, IPetService
    {
        private readonly IOwnerService _ownerService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IPetRepository _repository;

        public PetService(IPetRepository repository,
            IMapper mapper,
            IOwnerService ownerService,
            IHttpClientFactory httpClientFactory) : base(repository, mapper)
        {
            _repository = repository;
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

            if (result is not null)
            {
                var client = _httpClientFactory.CreateClient(ClientsConfiguration.ScheduleClientName);

                await client.DeleteAsync($"/api/Reminder/api/Pet/{id}", cancellationToken);
            }

            return _mapper.Map<PetModel>(result);
        }

        public async Task<IEnumerable<PetModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByOwnerId(ownerId, cancellationToken);

            return _mapper.Map<IEnumerable<PetModel>>(result);
        }
    }
}
