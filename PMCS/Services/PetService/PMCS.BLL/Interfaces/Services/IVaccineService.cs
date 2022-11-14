using PMCS.BLL.Models;

namespace PMCS.BLL.Interfaces.Services
{
    public interface IVaccineService : IGenericService<VaccineModel>
    {
        Task<IEnumerable<VaccineModel>> GetByOwnerId(int ownerId, CancellationToken cancellationToken);
    }
}
