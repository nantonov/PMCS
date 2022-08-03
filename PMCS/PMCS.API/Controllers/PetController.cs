﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.Validators;
using PMCS.API.ViewModels.Pet;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _service;
        private readonly IMapper _mapper;
        private readonly PostPetValidator _postPetValidator;
        private readonly UpdatePetValidator _updatePetValidator;

        public PetController(IPetService petService, IMapper mapper, PostPetValidator postPetValidator, UpdatePetValidator updatePetValidator)
        {
            _service = petService;
            _mapper = mapper;
            _postPetValidator = postPetValidator;
            _updatePetValidator = updatePetValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<PetViewModel>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<PetViewModel>>(await _service.GetAll(cancellationToken));
        }


        [HttpGet("{id}")]
        public async Task<PetViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            return _mapper.Map<PetViewModel>(await _service.GetById(id, cancellationToken));
        }

        [HttpPost]
        public async Task<PetViewModel> Add([FromBody] PostPetViewModel viewModel, CancellationToken cancellationToken)
        {
            await _postPetValidator.ValidateAsync(viewModel, cancellationToken);

            var model = _mapper.Map<PetModel>(viewModel);

            return _mapper.Map<PetViewModel>(await _service.Add(model, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<PetViewModel> Update(int id, [FromBody] UpdatePetViewModel viewModel, CancellationToken cancellationToken)
        {
            await _updatePetValidator.ValidateAsync(viewModel, cancellationToken);

            var model = _mapper.Map<PetModel>(viewModel);
            model.Id = id;

            return _mapper.Map<PetViewModel>(await _service.Update(id, model, cancellationToken));
        }
    }
}
