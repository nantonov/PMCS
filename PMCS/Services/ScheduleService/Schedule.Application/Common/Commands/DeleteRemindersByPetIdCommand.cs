using MediatR;
using Schedule.Domain.Entities;

namespace Schedule.Application.Common.Commands
{
    public record DeleteRemindersByPetIdCommand(int PetId) : IRequest<IReadOnlyList<Reminder>>;
}
