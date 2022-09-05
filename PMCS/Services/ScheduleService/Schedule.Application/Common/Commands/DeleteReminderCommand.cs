using MediatR;
using Schedule.Domain.Entities;

namespace Schedule.Application.Common.Commands
{
    public record DeleteReminderCommand(int Id) : IRequest<Reminder>;
}
