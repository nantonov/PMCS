using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.Validators;
using PMCS.API.ViewModels.Owner;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _service;
        private readonly IMapper _mapper;
        private PostOwnerValidator _postOwnerValidator;
        private UpdateOwnerValidator _updateOwnerValidator;

        public OwnerController(IOwnerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OwnerViewModel>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<OwnerViewModel>>(await _service.GetAll(cancellationToken));
        }


        [HttpGet("{id}")]
        public async Task<OwnerViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            return _mapper.Map<OwnerViewModel>(await _service.GetById(id, cancellationToken));
        }

        [HttpPost]
        public async Task<OwnerViewModel> Insert([FromBody] PostOwnerViewModel viewModel, [FromServices] PostOwnerValidator postOwnerValidator, CancellationToken cancellationToken)
        {
            _postOwnerValidator = postOwnerValidator;

            await _postOwnerValidator.ValidateAsync(viewModel, cancellationToken);

            var model = _mapper.Map<OwnerModel>(viewModel);

            return _mapper.Map<OwnerViewModel>(await _service.Insert(model, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<OwnerViewModel> Update(int id, [FromBody] UpdateOwnerViewModel viewModel, [FromServices] UpdateOwnerValidator updateOwnerValidator, CancellationToken cancellationToken)
        {
            _updateOwnerValidator = updateOwnerValidator;

            await _updateOwnerValidator.ValidateAsync(viewModel, cancellationToken);

            var model = _mapper.Map<OwnerModel>(viewModel);

            return _mapper.Map<OwnerViewModel>(await _service.Update(id, model, cancellationToken));
        }


    }
}
