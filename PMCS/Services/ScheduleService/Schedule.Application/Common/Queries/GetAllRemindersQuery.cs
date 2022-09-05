using MediatR;
using Schedule.Domain.Entities;

namespace Schedule.Application.Common.Queries
{
    public record GetAllRemindersQuery() : IRequest<IReadOnlyList<Reminder>>;
}
