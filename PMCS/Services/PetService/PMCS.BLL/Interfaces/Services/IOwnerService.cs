using PMCS.BLL.Models;

namespace PMCS.BLL.Interfaces.Services
{
    public interface IOwnerService : IGenericService<OwnerModel>
    {
        Task<OwnerModel> GetByExternalId(int externalId, CancellationToken cancellationToken);
    }
}
