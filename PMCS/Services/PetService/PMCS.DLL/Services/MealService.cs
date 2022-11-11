﻿using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Exceptions;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.DLL.Services
{
    public class MealService : GenericService<MealModel, MealEntity>, IMealService
    {
        private readonly IPetService _petService;
        public MealService(IMealRepository repository, IMapper mapper, IPetService petService) : base(repository, mapper)
        {
            ArgumentNullException.ThrowIfNull(petService);

            _petService = petService;
        }

        public override async Task<MealModel> Update(MealModel model, CancellationToken cancellationToken)
        {
            if (!await IsModelExists(model.Id, cancellationToken) || !await _petService.IsModelExists(model.PetId, cancellationToken))
                throw new ModelIsNotFoundException();

            var entity = _mapper.Map<MealEntity>(model);

            var result = await _repository.Update(entity, cancellationToken);

            return _mapper.Map<MealModel>(result);
        }

        public async Task<IEnumerable<MealModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByPredicate(x => x.Pet.OwnerId == ownerId, cancellationToken);

            var result = _mapper.Map<IEnumerable<MealModel>>(entities);

            return result;
        }
    }
}
