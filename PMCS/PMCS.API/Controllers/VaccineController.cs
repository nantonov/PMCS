using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.ViewModels.Vaccine;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineService _service;
        private readonly IMapper _mapper;

        public VaccineController(IVaccineService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VaccineViewModel>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<VaccineViewModel>>(await _service.GetAll(cancellationToken));
        }


        [HttpGet("{id}")]
        public async Task<VaccineViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            return _mapper.Map<VaccineViewModel>(await _service.GetById(id, cancellationToken));
        }

        [HttpPost]
        public async Task<VaccineViewModel> Add([FromBody] PostVaccineViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<VaccineModel>(viewModel);

            return _mapper.Map<VaccineViewModel>(await _service.Add(model, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<VaccineViewModel> Update(int id, [FromBody] UpdateVaccineViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<VaccineModel>(viewModel);

            return _mapper.Map<VaccineViewModel>(await _service.Update(model, cancellationToken));
        }
    }
}
