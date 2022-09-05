using MediatR;
using Schedule.Domain.Entities;

namespace Schedule.Application.Common.Queries
{
    public record GetUserRemindersQuery(int Id) : IRequest<IReadOnlyList<Reminder>>;
}
