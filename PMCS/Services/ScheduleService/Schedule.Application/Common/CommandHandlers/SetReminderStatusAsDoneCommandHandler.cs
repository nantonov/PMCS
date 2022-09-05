using AutoMapper;
using MediatR;
using Schedule.Application.Common.Commands;
using Schedule.Domain.Core.Exceptions;
using Schedule.Domain.Entities;
using Schedule.Domain.Repositories;

namespace Schedule.Application.Common.CommandHandlers
{
    public class SetReminderStatusAsDoneCommandHandler : IRequestHandler<SetReminderStatusAsDoneCommand, Reminder>
    {
        private readonly IReminderRepository _repository;

        public SetReminderStatusAsDoneCommandHandler(IReminderRepository repository, IMapper mapper)
        {
            _repository = repository;
        }

        public async Task<Reminder> Handle(SetReminderStatusAsDoneCommand request, CancellationToken cancellationToken)
        {
            var reminder = await _repository.GetById(request.Id, cancellationToken);

            if (reminder == null) throw new EntityDoesNotExistException(request.Id);

            reminder.SetStatusAsDone();

            var result = await _repository.Update(reminder, cancellationToken);

            return result;
        }
    }
}
