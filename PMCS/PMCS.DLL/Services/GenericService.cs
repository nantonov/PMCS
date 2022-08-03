using AutoMapper;
using PMCS.DAL.Interfaces.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Interfaces.Models;
using PMCS.DLL.Interfaces.Services;

namespace PMCS.DLL.Services
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel>
        where TEntity : IHasIdEntity
        where TModel : IHasIdModel
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public virtual async Task<TModel> Add(TModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(model);

            return _mapper.Map<TModel>(await _repository.Insert(entity, cancellationToken));
        }

        public virtual async Task<IEnumerable<TModel>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<TModel>>(await _repository.Get(cancellationToken));
        }

        public virtual async Task<TModel> GetById(int id, CancellationToken cancellationToken)
        {
            return _mapper.Map<TModel>(await _repository.GetById(id, cancellationToken));
        }

        public virtual async Task<TModel> Delete(int id, CancellationToken cancellationToken)
        {
            return _mapper.Map<TModel>(await _repository.Delete(id, cancellationToken));
        }

        public virtual async Task<TModel> Update(TModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(model);

            return _mapper.Map<TModel>(await _repository.Update(entity, cancellationToken));
        }
    }
}
