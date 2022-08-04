using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public WalkingController(IWalkingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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
            var model = _mapper.Map<WalkingModel>(viewModel);

            return _mapper.Map<WalkingViewModel>(await _service.Update(model, cancellationToken));
        }
    }
}
