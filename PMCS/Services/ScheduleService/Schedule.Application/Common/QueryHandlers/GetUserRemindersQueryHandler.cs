using MediatR;
using Schedule.Application.Common.Queries;
using Schedule.Domain.Entities;
using Schedule.Domain.Repositories;

namespace Schedule.Application.Common.QueryHandlers
{
    public class GetUserRemindersQueryHandler : IRequestHandler<GetUserRemindersQuery, IReadOnlyList<Reminder>>
    {
        private readonly IReminderRepository _repository;

        public GetUserRemindersQueryHandler(IReminderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<Reminder>> Handle(GetUserRemindersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetUserReminders(request.Id, cancellationToken);

            return result;
        }
    }
}
