using MediatR;
using Schedule.Application.Common.Queries;
using Schedule.Domain.Entities;
using Schedule.Domain.Repositories;

namespace Schedule.Application.Common.QueryHandlers
{
    public class GetRemindersToTriggerQueryHandler : IRequestHandler<GetRemindersToTriggerQuery, IReadOnlyList<Reminder>>
    {
        private readonly IReminderRepository _repository;

        public GetRemindersToTriggerQueryHandler(IReminderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<Reminder>> Handle(GetRemindersToTriggerQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Get(x => x.TriggerDateTime <= DateTime.UtcNow && x.IsTriggered == false, cancellationToken);

            return result;
        }
    }
}
