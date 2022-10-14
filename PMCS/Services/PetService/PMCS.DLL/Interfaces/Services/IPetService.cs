using PMCS.DLL.Models;

namespace PMCS.DLL.Interfaces.Services
{
    public interface IPetService : IGenericService<PetModel>
    {
        Task<IEnumerable<PetModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken);
    }
}
