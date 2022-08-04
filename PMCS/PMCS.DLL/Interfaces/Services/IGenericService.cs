namespace PMCS.DLL.Interfaces.Services
{
    public interface IGenericService<TModel>
    {
        Task<TModel> Add(TModel model, CancellationToken cancellationToken);
        Task<IEnumerable<TModel>> GetAll(CancellationToken cancellationToken);
        Task<TModel> GetById(int id, CancellationToken cancellationToken);
        Task<TModel> Delete(int id, CancellationToken cancellationToken);
        Task<TModel> Update(TModel model, CancellationToken cancellationToken);
        Task<bool> IsModelExists(int id, CancellationToken cancellationToken);
    }
}
