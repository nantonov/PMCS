using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMCS.API.Constants.Authorization;
using PMCS.API.Validators;
using PMCS.API.ViewModels.Vaccine;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(PolicyBasedAuthorizationParameters.AllMethodsAllowedPolicy)]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineService _service;
        private readonly IMapper _mapper;
        private readonly PostVaccineValidator _postVaccineValidator;
        private readonly UpdateVaccineValidator _updateVaccineValidator;

        public VaccineController(IVaccineService service, IMapper mapper, PostVaccineValidator postVaccineValidator, UpdateVaccineValidator updateVaccineValidator)
        {
            ArgumentNullException.ThrowIfNull(service);
            ArgumentNullException.ThrowIfNull(mapper);
            ArgumentNullException.ThrowIfNull(updateVaccineValidator);
            ArgumentNullException.ThrowIfNull(postVaccineValidator);

            _service = service;
            _mapper = mapper;
            _postVaccineValidator = postVaccineValidator;
            _updateVaccineValidator = updateVaccineValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<VaccineViewModel>> GetAll(CancellationToken cancellationToken)
        {
            var models = await _service.GetAll(cancellationToken);

            return _mapper.Map<IEnumerable<VaccineViewModel>>(models);
        }

        [HttpGet("{id}")]
        public async Task<VaccineViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            var model = await _service.GetById(id, cancellationToken);

            return _mapper.Map<VaccineViewModel>(model);
        }

        [HttpPost]
        public async Task<VaccineViewModel> Add([FromBody] PostVaccineViewModel viewModel, CancellationToken cancellationToken)
        {
            await _postVaccineValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var model = _mapper.Map<VaccineModel>(viewModel);

            var result = await _service.Add(model, cancellationToken);

            return _mapper.Map<VaccineViewModel>(result);
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

            var model = _mapper.Map<VaccineModel>(viewModel);

            model.Id = id;

            var result = await _service.Update(model, cancellationToken);

            return _mapper.Map<VaccineViewModel>(result);
        }


        [HttpGet("owner/{ownerId}")]
        public async Task<IEnumerable<VaccineViewModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken)
        {
            var result = await _service.GetByOwnerId(ownerId, cancellationToken);

            return _mapper.Map<IEnumerable<VaccineViewModel>>(result);
        }
    }
}
