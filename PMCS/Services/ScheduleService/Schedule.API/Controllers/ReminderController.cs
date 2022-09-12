﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedule.API.Requests;
using Schedule.API.ViewModels;
using Schedule.Application.Common.Commands;
using Schedule.Application.Common.Queries;

namespace Schedule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReminderController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IMapper _mapper;

        public ReminderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllReminders(CancellationToken cancellationToken = default)
        {
            var query = new GetAllRemindersQuery();
            var reminders = await _mediator.Send(query, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<ReminderViewModel>>(reminders);

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetRemindersByUserId(int userId, CancellationToken cancellationToken = default)
        {
            var query = new GetUserRemindersQuery(userId);
            var reminders = await _mediator.Send(query, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<ReminderViewModel>>(reminders);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddReminder(PostReminderRequest request, CancellationToken cancellationToken = default)
        {
            var command = _mapper.Map<AddReminderCommand>(request);
            var reminder = await _mediator.Send(command, cancellationToken);

            var result = _mapper.Map<ReminderViewModel>(reminder);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateReminder(PutReminderRequest request, CancellationToken cancellationToken = default)
        {
            var command = _mapper.Map<UpdateReminderCommand>(request);
            var reminder = await _mediator.Send(command, cancellationToken);

            var result = _mapper.Map<ReminderViewModel>(reminder);

            return Ok(result);
        }

        [HttpPut("/complete/{id}")]
        public async Task<ActionResult> SetReminderStatusAsDone(int id, CancellationToken cancellationToken = default)
        {
            var command = new SetReminderStatusAsDoneCommand(id);
            var reminder = await _mediator.Send(command, cancellationToken);

            var result = _mapper.Map<ReminderViewModel>(reminder);

            return Ok(result);
        }

        [HttpPut("/reset/{id}")]
        public async Task<ActionResult> ResetReminderStatus(int id, CancellationToken cancellationToken = default)
        {
            var command = new ResetReminderStatusCommand(id);
            var reminder = await _mediator.Send(command, cancellationToken);

            var result = _mapper.Map<ReminderViewModel>(reminder);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReminder(int id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteReminderCommand(id);

            var reminder = await _mediator.Send(command, cancellationToken);

            var result = _mapper.Map<ReminderViewModel>(reminder);

            return Ok(result);
        }
    }
}