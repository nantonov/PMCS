using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.Validators;
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
        private readonly PostVaccineValidator _postVaccineValidator;
        private readonly UpdateVaccineValidator _updateVaccineValidator;

        public VaccineController(IVaccineService service, IMapper mapper, PostVaccineValidator postVaccineValidator, UpdateVaccineValidator updateVaccineValidator)
        {
            _service = service;
            _mapper = mapper;
            _postVaccineValidator = postVaccineValidator;
            _updateVaccineValidator = updateVaccineValidator;
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
            await _postVaccineValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

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
            await _updateVaccineValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var petId = GetPetId(id, cancellationToken);

            var model = _mapper.Map<VaccineModel>(viewModel);

            model.Id = id;
            model.PetId = petId;

            return _mapper.Map<VaccineViewModel>(await _service.Update(model, cancellationToken));
        }

        private async Task<int> GetPetId(int petId, CancellationToken cancellationToken)
        {
            var model = await _service.GetById(petId, cancellationToken);
            if (model == null) throw new ModelIsNotFoundException();

            return model.PetId;
        }
    }
}
