using MediatR;
using Schedule.Domain.Entities;

namespace Schedule.Application.Common.Commands
{
    public record ResetReminderStatusCommand(int Id) : IRequest<Reminder>;
}
