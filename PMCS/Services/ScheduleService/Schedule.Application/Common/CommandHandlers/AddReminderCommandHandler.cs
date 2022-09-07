using MediatR;
using Schedule.Application.Common.Commands;
using Schedule.Application.Core.Abstractions.Services;
using Schedule.Domain.Entities;
using Schedule.Domain.Repositories;

namespace Schedule.Application.Common.CommandHandlers
{
    public class AddReminderCommandHandler : IRequestHandler<AddReminderCommand, Reminder>
    {
        private readonly IReminderRepository _repository;
        private readonly IIdentityService _identityService;

        public AddReminderCommandHandler(IReminderRepository repository, IIdentityService identityService)
        {
            _repository = repository;
            _identityService = identityService;
        }

        public async Task<Reminder> Handle(AddReminderCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityService.GetUserId();
            var userEmail = _identityService.GetUserEmail();

            var reminder = new Reminder(request.TriggerDateTime, request.PetId,
                userId, request.NotificationMessage, userEmail, request.NotificationType, request.ActionToRemindType);

            var result = await _repository.Insert(reminder, cancellationToken);

            return result;
        }
    }
}
