using PMCS.DLL.Interfaces.Models;

namespace PMCS.DLL.Interfaces.Services
{
    public interface IGenericService<TModel> where TModel : IHasIdModel
    {
        Task<TModel> Insert(TModel model, CancellationToken cancellationToken);
        Task<IEnumerable<TModel>> GetAll (CancellationToken cancellationToken);
        Task<TModel> GetById(int id, CancellationToken cancellationToken);
        Task<TModel> Delete(int id, CancellationToken cancellationToken);
        Task<TModel> Update(int id, TModel model, CancellationToken cancellationToken);
    }
}
