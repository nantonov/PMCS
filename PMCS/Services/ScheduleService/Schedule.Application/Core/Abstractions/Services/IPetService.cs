using Schedule.Application.Core.Models.Pets.Owner;

namespace Schedule.Application.Core.Abstractions.Services
{
    public interface IPetService
    {
        Task<Owner> GetOwner(int userId);
    }
}
