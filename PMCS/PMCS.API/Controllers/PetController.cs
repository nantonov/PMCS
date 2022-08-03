using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.Exceptions;
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
            if (!await IsModelExists(id, cancellationToken)) throw new ModelIsNotFoundException();

            return _mapper.Map<PetViewModel>(await _service.GetById(id, cancellationToken));
        }

        [HttpPost]
        public async Task<PetViewModel> Add([FromBody] PostPetViewModel viewModel, CancellationToken cancellationToken)
        {
            await _postPetValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var model = _mapper.Map<PetModel>(viewModel);

            return _mapper.Map<PetViewModel>(await _service.Add(model, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            if (!await IsModelExists(id, cancellationToken)) throw new ModelIsNotFoundException();

            await _service.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<PetViewModel> Update(int id, [FromBody] UpdatePetViewModel viewModel, CancellationToken cancellationToken)
        {
            await _updatePetValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var ownerId = await GetPetsOwnerId(id, cancellationToken);

            var model = _mapper.Map<PetModel>(viewModel);

            model.Id = id;
            model.OwnerId = ownerId;

            return _mapper.Map<PetViewModel>(await _service.Update(model, cancellationToken));
        }

        private async Task<int> GetPetsOwnerId(int petId, CancellationToken cancellationToken)
        {
            var pet = await _service.GetById(petId, cancellationToken);
            if (pet == null) throw new ModelIsNotFoundException();

            return pet.OwnerId;
        }

        private async Task<bool> IsModelExists(int id, CancellationToken cancellationToken)
        {
            var model = await _service.GetById(id, cancellationToken);

            if (model == null) return false;

            return true;
        }

    }
}
