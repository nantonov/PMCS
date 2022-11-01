using PMCS.DLL.Models;

namespace PMCS.DLL.Interfaces.Services
{
    public interface IWalkingService : IGenericService<WalkingModel>
    {
        Task<IEnumerable<WalkingModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken);
    }
}
