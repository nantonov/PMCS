﻿using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.Constants.Authorization;
using PMCS.API.Validators;
using PMCS.API.ViewModels.Pet;
using PMCS.BLL.Interfaces.Services;
using PMCS.BLL.Models;

namespace PMCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(PolicyBasedAuthorizationParameters.AllMethodsAllowedPolicy)]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;
        private readonly PostPetValidator _postPetValidator;
        private readonly UpdatePetValidator _updatePetValidator;

        public PetController(IPetService petService, IMapper mapper, PostPetValidator postPetValidator, UpdatePetValidator updatePetValidator)
        {
            ArgumentNullException.ThrowIfNull(petService);
            ArgumentNullException.ThrowIfNull(mapper);
            ArgumentNullException.ThrowIfNull(updatePetValidator);
            ArgumentNullException.ThrowIfNull(postPetValidator);

            _petService = petService;
            _mapper = mapper;
            _postPetValidator = postPetValidator;
            _updatePetValidator = updatePetValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<PetViewModel>> GetAll(CancellationToken cancellationToken)
        {
            var models = await _petService.GetAll(cancellationToken);

            return _mapper.Map<IEnumerable<PetViewModel>>(models);
        }


        [HttpGet("{id}")]
        public async Task<PetViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            var model = await _petService.GetById(id, cancellationToken);

            return _mapper.Map<PetViewModel>(model);
        }

        [HttpGet("ownerId/{ownerId}")]
        public async Task<IEnumerable<PetViewModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken)
        {
            var model = await _petService.GetByOwnerId(ownerId, cancellationToken);

            return _mapper.Map<IEnumerable<PetViewModel>>(model);
        }

        [HttpPost]
        public async Task<PetViewModel> Add([FromBody] PostPetViewModel viewModel, CancellationToken cancellationToken)
        {
            await _postPetValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var model = _mapper.Map<PetModel>(viewModel);

            var result = await _petService.Add(model, cancellationToken);

            return _mapper.Map<PetViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _petService.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<PetViewModel> Update(int id, [FromBody] UpdatePetViewModel viewModel, CancellationToken cancellationToken)
        {
            await _updatePetValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var model = _mapper.Map<PetModel>(viewModel);

            model.Id = id;

            var result = await _petService.Update(model, cancellationToken);

            return _mapper.Map<PetViewModel>(result);
        }
    }
}
