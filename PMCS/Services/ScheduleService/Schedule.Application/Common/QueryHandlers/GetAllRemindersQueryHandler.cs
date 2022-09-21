using MediatR;
using Schedule.Application.Common.Queries;
using Schedule.Domain.Entities;
using Schedule.Domain.Repositories;

namespace Schedule.Application.Common.QueryHandlers
{
    public class GetAllRemindersQueryHandler : IRequestHandler<GetAllRemindersQuery, IReadOnlyList<Reminder>>
    {
        private readonly IReminderRepository _repository;

        public GetAllRemindersQueryHandler(IReminderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<Reminder>> Handle(GetAllRemindersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll(cancellationToken);

            return result;
        }
    }
}
