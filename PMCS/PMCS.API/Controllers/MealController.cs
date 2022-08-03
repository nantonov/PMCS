using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.ViewModels.Meal;
using PMCS.API.ViewModels.Vaccine;
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

        public MealController(IMealService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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
        public async Task<MealViewModel> Insert([FromBody] PostMealViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<MealModel>(viewModel);

            return _mapper.Map<MealViewModel>(await _service.Insert(model, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<MealViewModel> Update(int id, [FromBody] UpdateMealViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<MealModel>(viewModel);

            return _mapper.Map<MealViewModel>(await _service.Update(model, cancellationToken));
        }
    }
}
