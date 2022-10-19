using MediatR;
using Schedule.Domain.Entities;

namespace Schedule.Application.Common.Queries
{
    public record GetUserRemindersQuery() : IRequest<IReadOnlyList<Reminder>>;
}
