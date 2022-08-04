using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.Validators;
using PMCS.API.ViewModels.Meal;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _service;
        private readonly IMapper _mapper;
        private readonly PostMealValidator _postMealValidator;
        private readonly UpdateMealValidator _updateMealValidator;

        public MealController(IMealService service, IMapper mapper, UpdateMealValidator updateMealValidator, PostMealValidator postMealValidator)
        {
            _service = service;
            _mapper = mapper;
            _updateMealValidator = updateMealValidator;
            _postMealValidator = postMealValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<MealViewModel>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<MealViewModel>>(await _service.GetAll(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<MealViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            return _mapper.Map<MealViewModel>(await _service.GetById(id, cancellationToken));
        }

        [HttpPost]
        public async Task<MealViewModel> Add([FromBody] PostMealViewModel viewModel, CancellationToken cancellationToken)
        {
            await _postMealValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var model = _mapper.Map<MealModel>(viewModel);

            return _mapper.Map<MealViewModel>(await _service.Add(model, cancellationToken));
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

            return _mapper.Map<MealViewModel>(await _service.Update(model, cancellationToken));
        }
    }
}
