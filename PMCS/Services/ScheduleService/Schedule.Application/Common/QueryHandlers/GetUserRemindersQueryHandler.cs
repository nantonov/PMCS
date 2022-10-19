using MediatR;
using Schedule.Application.Common.Queries;
using Schedule.Application.Core.Abstractions.Services;
using Schedule.Domain.Entities;
using Schedule.Domain.Repositories;

namespace Schedule.Application.Common.QueryHandlers
{
    public class GetUserRemindersQueryHandler : IRequestHandler<GetUserRemindersQuery, IReadOnlyList<Reminder>>
    {
        private readonly IReminderRepository _repository;
        private readonly IIdentityService _identityService;

        public GetUserRemindersQueryHandler(IReminderRepository repository, IIdentityService identityService)
        {
            _repository = repository;
            _identityService = identityService;
        }

        public async Task<IReadOnlyList<Reminder>> Handle(GetUserRemindersQuery request, CancellationToken cancellationToken)
        {
            var userId = _identityService.GetUserId();
            var result = await _repository.GetUserReminders(userId, cancellationToken);

            return result;
        }
    }
}
