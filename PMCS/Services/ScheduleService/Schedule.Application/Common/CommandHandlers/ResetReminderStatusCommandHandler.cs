using MediatR;
using Schedule.Application.Common.Commands;
using Schedule.Domain.Core.Exceptions;
using Schedule.Domain.Entities;
using Schedule.Domain.Repositories;

namespace Schedule.Application.Common.CommandHandlers
{
    public class ResetReminderStatusCommandHandler : IRequestHandler<ResetReminderStatusCommand, Reminder>
    {
        private readonly IReminderRepository _repository;

        public ResetReminderStatusCommandHandler(IReminderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Reminder> Handle(ResetReminderStatusCommand request, CancellationToken cancellationToken)
        {
            var reminder = await _repository.GetById(request.Id, cancellationToken);

            if (reminder == null) throw new EntityDoesNotExistException(request.Id);

            reminder.ResetStatus();

            var result = await _repository.Update(reminder, cancellationToken);

            return result;
        }
    }
}
