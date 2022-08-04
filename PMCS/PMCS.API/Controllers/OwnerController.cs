﻿using AutoMapper;
using FluentValidation;
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
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;
        private readonly PostOwnerValidator _postOwnerValidator;
        private readonly UpdateOwnerValidator _updateOwnerValidator;

        public OwnerController(IOwnerService ownerService, IMapper mapper, PostOwnerValidator postOwnerValidator, UpdateOwnerValidator updateOwnerValidator)
        {
            _ownerService = ownerService;
            _mapper = mapper;
            _postOwnerValidator = postOwnerValidator;
            _updateOwnerValidator = updateOwnerValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<OwnerViewModel>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<OwnerViewModel>>(await _ownerService.GetAll(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<OwnerViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            return _mapper.Map<OwnerViewModel>(await _ownerService.GetById(id, cancellationToken));
        }

        [HttpPost]
        public async Task<OwnerViewModel> Add([FromBody] PostOwnerViewModel viewModel, CancellationToken cancellationToken)
        {
            await _postOwnerValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var model = _mapper.Map<OwnerModel>(viewModel);

            return _mapper.Map<OwnerViewModel>(await _ownerService.Add(model, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _ownerService.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<OwnerViewModel> Update(int id, [FromBody] UpdateOwnerViewModel viewModel, CancellationToken cancellationToken)
        {
            await _updateOwnerValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var model = _mapper.Map<OwnerModel>(viewModel);

            model.Id = id;

            return _mapper.Map<OwnerViewModel>(await _ownerService.Update(model, cancellationToken));
        }
    }
}
