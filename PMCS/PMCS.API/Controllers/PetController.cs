using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.ViewModels.Pet;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _service;
        private readonly IMapper _mapper;

        public PetController(IPetService petService, IMapper mapper)
        {
            _service = petService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PetViewModel>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<PetViewModel>>(await _service.GetAll(cancellationToken));
        }


        [HttpGet("{id}")]
        public async Task<PetViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            return _mapper.Map<PetViewModel>(await _service.GetById(id, cancellationToken));
        }

        [HttpPost]
        public async Task<PetViewModel> Insert([FromBody] PostPetViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<PetModel>(viewModel);

            return _mapper.Map<PetViewModel>(await _service.Insert(model, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        [HttpPut]
        public async Task<PetViewModel> Update([FromBody] UpdatePetViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<PetModel>(viewModel);

            return _mapper.Map<PetViewModel>(await _service.Update(model, cancellationToken));
        }
    }
}
