using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<OwnerViewModel> Insert([FromBody] PostOwnerViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<OwnerModel>(viewModel);

            return _mapper.Map<OwnerViewModel>(await _service.Insert(model, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        [HttpPut]
        public async Task<OwnerViewModel> Update([FromBody] UpdateOwnerViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<OwnerModel>(viewModel);

            return _mapper.Map<OwnerViewModel>(await _service.Update(model, cancellationToken));
        }
    }
}
