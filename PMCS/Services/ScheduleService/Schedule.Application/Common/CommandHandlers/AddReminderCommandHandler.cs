using AutoMapper;
using MediatR;
using Schedule.Application.Common.Commands;
using Schedule.Domain.Entities;
using Schedule.Domain.Repositories;

namespace Schedule.Application.Common.CommandHandlers
{
    public class AddReminderCommandHandler : IRequestHandler<AddReminderCommand, Reminder>
    {
        private readonly IReminderRepository _repository;

        public AddReminderCommandHandler(IReminderRepository repository, IMapper mapper)
        {
            _repository = repository;
        }

        public async Task<Reminder> Handle(AddReminderCommand request, CancellationToken cancellationToken)
        {
            var reminder = new Reminder(request.TriggerDateTime, request.PetId,
                request.UserId, request.NotificationMessage, request.NotificationType, request.ActionToRemindType);

            var result = await _repository.Insert(reminder, cancellationToken);

            return result;
        }
    }
}
