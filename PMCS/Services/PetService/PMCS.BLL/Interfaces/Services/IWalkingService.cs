using PMCS.BLL.Models;

namespace PMCS.BLL.Interfaces.Services
{
    public interface IWalkingService : IGenericService<WalkingModel>
    {
        Task<IEnumerable<WalkingModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken);
    }
}
