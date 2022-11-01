using PMCS.DLL.Models;

namespace PMCS.DLL.Interfaces.Services
{
    public interface IMealService : IGenericService<MealModel>
    {
        Task<IEnumerable<MealModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken);
    }
}
