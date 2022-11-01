using PMCS.DLL.Models;

namespace PMCS.DLL.Interfaces.Services
{
    public interface IVaccineService : IGenericService<VaccineModel>
    {
        Task<IEnumerable<VaccineModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken);
    }
}
