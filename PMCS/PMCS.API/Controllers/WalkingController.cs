using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.Validators;
using PMCS.API.ViewModels.Walking;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkingController : ControllerBase
    {
        private readonly IWalkingService _service;
        private readonly IMapper _mapper;
        private readonly PostWalkingValidator _postWalkingValidator;
        private readonly UpdateWalkingValidator _updateWalkingValidator;

        public WalkingController(IWalkingService service, IMapper mapper, PostWalkingValidator postWalkingValidator, UpdateWalkingValidator updateWalkingValidator)
        {
            _service = service;
            _mapper = mapper;
            _postWalkingValidator = postWalkingValidator;
            _updateWalkingValidator = updateWalkingValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<WalkingViewModel>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<WalkingViewModel>>(await _service.GetAll(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<WalkingViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            return _mapper.Map<WalkingViewModel>(await _service.GetById(id, cancellationToken));
        }

        [HttpPost]
        public async Task<WalkingViewModel> Add([FromBody] PostWalkingViewModel viewModel, CancellationToken cancellationToken)
        {
            await _postWalkingValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var model = _mapper.Map<WalkingModel>(viewModel);

            return _mapper.Map<WalkingViewModel>(await _service.Add(model, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<WalkingViewModel> Update(int id, [FromBody] UpdateWalkingViewModel viewModel, CancellationToken cancellationToken)
        {
            await _updateWalkingValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var petId = GetPetId(id, cancellationToken);

            var model = _mapper.Map<WalkingModel>(viewModel);

            model.Id = id;
            model.PetId = petId;

            return _mapper.Map<WalkingViewModel>(await _service.Update(model, cancellationToken));
        }
        private async Task<int> GetPetId(int petId, CancellationToken cancellationToken)
        {
            var model = await _service.GetById(petId, cancellationToken);
            if (model == null) throw new ModelIsNotFoundException();

            return model.PetId;
        }
    }
}
