using MediatR;
using Schedule.Domain.Entities;

namespace Schedule.Application.Common.Queries
{
    public record GetRemindersToTriggerQuery(DateTime DateTime) : IRequest<IReadOnlyList<Reminder>>;
}
