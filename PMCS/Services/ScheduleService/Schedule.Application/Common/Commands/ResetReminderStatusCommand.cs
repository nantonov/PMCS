using MediatR;
using Schedule.Domain.Entities;

namespace Schedule.Application.Common.Commands
{
    public record SetReminderStatusAsDoneCommand(int Id) : IRequest<Reminder>;
}
