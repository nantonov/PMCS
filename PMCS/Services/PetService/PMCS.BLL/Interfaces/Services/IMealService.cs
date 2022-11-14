using PMCS.BLL.Models;

namespace PMCS.BLL.Interfaces.Services
{
    public interface IMealService : IGenericService<MealModel>
    {
        Task<IEnumerable<MealModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken);
    }
}
