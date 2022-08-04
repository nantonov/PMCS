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
        private readonly IPetService _petService;
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;
        private readonly PostPetValidator _postPetValidator;
        private readonly UpdatePetValidator _updatePetValidator;

        public PetController(IPetService petService, IOwnerService ownerService, IMapper mapper, PostPetValidator postPetValidator, UpdatePetValidator updatePetValidator)
        {
            _petService = petService;
            _ownerService = ownerService;
            _mapper = mapper;
            _postPetValidator = postPetValidator;
            _updatePetValidator = updatePetValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<PetViewModel>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<PetViewModel>>(await _petService.GetAll(cancellationToken));
        }


        [HttpGet("{id}")]
        public async Task<PetViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            if (!await IsPetExists(id, cancellationToken)) throw new ModelIsNotFoundException();

            return _mapper.Map<PetViewModel>(await _petService.GetById(id, cancellationToken));
        }

        [HttpPost]
        public async Task<PetViewModel> Add([FromBody] PostPetViewModel viewModel, CancellationToken cancellationToken)
        {
            await _postPetValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var model = _mapper.Map<PetModel>(viewModel);

            return _mapper.Map<PetViewModel>(await _petService.Add(model, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            if (!await IsPetExists(id, cancellationToken)) throw new ModelIsNotFoundException();

            await _petService.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<PetViewModel> Update(int id, [FromBody] UpdatePetViewModel viewModel, CancellationToken cancellationToken)
        {
            await _updatePetValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            if (!await IsOwnerExists(viewModel.OwnerId, cancellationToken) || !await IsPetExists(id, cancellationToken)) throw new ModelIsNotFoundException();

            var model = _mapper.Map<PetModel>(viewModel);

            model.Id = id;

            return _mapper.Map<PetViewModel>(await _petService.Update(model, cancellationToken));
        }

        private async Task<bool> IsPetExists(int id, CancellationToken cancellationToken) => await _petService.IsModelExists(id, cancellationToken);

        private async Task<bool> IsOwnerExists(int id, CancellationToken cancellationToken) => await _ownerService.IsModelExists(id, cancellationToken);

    }
}
