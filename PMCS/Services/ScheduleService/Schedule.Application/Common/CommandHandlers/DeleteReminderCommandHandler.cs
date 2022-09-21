using MediatR;
using Schedule.Application.Common.Commands;
using Schedule.Domain.Core.Exceptions;
using Schedule.Domain.Entities;
using Schedule.Domain.Repositories;

namespace Schedule.Application.Common.CommandHandlers
{
    public class DeleteReminderCommandHandler : IRequestHandler<DeleteReminderCommand, Reminder>
    {
        private readonly IReminderRepository _repository;

        public DeleteReminderCommandHandler(IReminderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Reminder> Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
        {
            var reminder = await _repository.GetById(request.Id, cancellationToken);

            if (reminder == null) throw new EntityDoesNotExistException(request.Id);

            var result = await _repository.Delete(reminder, cancellationToken);

            return result;
        }
    }
}
