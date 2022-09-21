using MediatR;
using Schedule.Application.Common.Commands;
using Schedule.Domain.Core.Exceptions;
using Schedule.Domain.Entities;
using Schedule.Domain.Repositories;

namespace Schedule.Application.Common.CommandHandlers
{
    public class DeleteRemindersByPetIdCommandHandler : IRequestHandler<DeleteRemindersByPetIdCommand, IReadOnlyList<Reminder>>
    {
        private readonly IReminderRepository _repository;

        public DeleteRemindersByPetIdCommandHandler(IReminderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<Reminder>> Handle(DeleteRemindersByPetIdCommand request, CancellationToken cancellationToken)
        {
            var reminder = await _repository.Get(x => x.PetId == request.PetId, cancellationToken);

            if (reminder == null) throw new EntityDoesNotExistException($"There is no reminder for pet with Id {request.PetId}");

            var result = await _repository.DeleteRange(reminder, cancellationToken);

            return result;
        }
    }
}
