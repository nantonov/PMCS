using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.Validators;
using PMCS.API.ViewModels.Walking;
using PMCS.BLL.Interfaces.Services;
using PMCS.BLL.Models;

namespace PMCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var models = await _service.GetAll(cancellationToken);

            return _mapper.Map<IEnumerable<WalkingViewModel>>(models);
        }

        [HttpGet("{id}")]
        public async Task<WalkingViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            var model = await _service.GetById(id, cancellationToken);

            return _mapper.Map<WalkingViewModel>(model);
        }

        [HttpPost]
        public async Task<WalkingViewModel> Add([FromBody] PostWalkingViewModel viewModel, CancellationToken cancellationToken)
        {
            await _postWalkingValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var model = _mapper.Map<WalkingModel>(viewModel);

            var result = await _service.Add(model, cancellationToken);

            return _mapper.Map<WalkingViewModel>(result);
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

            var model = _mapper.Map<WalkingModel>(viewModel);

            model.Id = id;

            var result = await _service.Update(model, cancellationToken);

            return _mapper.Map<WalkingViewModel>(result);
        }


        [HttpGet("owner/{ownerId}")]
        public async Task<IEnumerable<WalkingViewModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken)
        {
            var result = await _service.GetByOwnerId(ownerId, cancellationToken);

            return _mapper.Map<IEnumerable<WalkingViewModel>>(result);
        }
    }
}
