using PMCS.BLL.Models;

namespace PMCS.BLL.Interfaces.Services
{
    public interface IPetService : IGenericService<PetModel>
    {
        Task<IEnumerable<PetModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken);
    }
}
