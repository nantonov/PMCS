using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.Constants.Authorization;
using PMCS.API.Validators;
using PMCS.API.ViewModels.Meal;
using PMCS.BLL.Interfaces.Services;
using PMCS.BLL.Models;

namespace PMCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(PolicyBasedAuthorizationParameters.AllMethodsAllowedPolicy)]
    public class MealController : ControllerBase
    {
        private readonly IMealService _service;
        private readonly IMapper _mapper;
        private readonly PostMealValidator _postMealValidator;
        private readonly UpdateMealValidator _updateMealValidator;

        public MealController(IMealService service, IMapper mapper, UpdateMealValidator updateMealValidator, PostMealValidator postMealValidator)
        {
            ArgumentNullException.ThrowIfNull(service);
            ArgumentNullException.ThrowIfNull(mapper);
            ArgumentNullException.ThrowIfNull(updateMealValidator);
            ArgumentNullException.ThrowIfNull(postMealValidator);

            _service = service;
            _mapper = mapper;
            _updateMealValidator = updateMealValidator;
            _postMealValidator = postMealValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<MealViewModel>> GetAll(CancellationToken cancellationToken)
        {
            var models = await _service.GetAll(cancellationToken);

            return _mapper.Map<IEnumerable<MealViewModel>>(models);
        }

        [HttpGet("{id}")]
        public async Task<MealViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            var model = await _service.GetById(id, cancellationToken);

            return _mapper.Map<MealViewModel>(model);
        }

        [HttpPost]
        public async Task<MealViewModel> Add([FromBody] PostMealViewModel viewModel, CancellationToken cancellationToken)
        {
            await _postMealValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var model = _mapper.Map<MealModel>(viewModel);

            var result = await _service.Add(model, cancellationToken);

            return _mapper.Map<MealViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<MealViewModel> Update(int id, [FromBody] UpdateMealViewModel viewModel, CancellationToken cancellationToken)
        {
            await _updateMealValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var model = _mapper.Map<MealModel>(viewModel);

            model.Id = id;

            var result = await _service.Update(model, cancellationToken);

            return _mapper.Map<MealViewModel>(result);
        }

        [HttpGet("owner/{ownerId}")]
        public async Task<IEnumerable<MealViewModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken)
        {
            var result = await _service.GetByOwnerId(ownerId, cancellationToken);

            return _mapper.Map<IEnumerable<MealViewModel>>(result);
        }
    }
}
