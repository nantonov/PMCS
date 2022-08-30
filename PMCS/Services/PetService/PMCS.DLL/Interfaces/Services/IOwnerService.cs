using PMCS.DLL.Models;

namespace PMCS.DLL.Interfaces.Services
{
    public interface IOwnerService : IGenericService<OwnerModel>
    {
        Task<OwnerModel> GetByExternalId(int externalId, CancellationToken cancellationToken);
    }
}
