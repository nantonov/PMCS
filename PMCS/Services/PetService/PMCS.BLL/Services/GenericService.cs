﻿using AutoMapper;
using PMCS.BLL.Exceptions;
using PMCS.BLL.Interfaces.Models;
using PMCS.BLL.Interfaces.Services;
using PMCS.DAL.Interfaces.Entities;
using PMCS.DAL.Interfaces.Repositories;

namespace PMCS.BLL.Services
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

            var result = await _repository.Insert(entity, cancellationToken);

            return _mapper.Map<TModel>(result);
        }

        public virtual async Task<IEnumerable<TModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _repository.Get(cancellationToken);

            return _mapper.Map<IEnumerable<TModel>>(result);
        }

        public virtual async Task<TModel> GetById(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(id, cancellationToken);

            if (entity == null) throw new ModelIsNotFoundException();

            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> Delete(int id, CancellationToken cancellationToken)
        {
            if (!await IsModelExists(id, cancellationToken)) throw new ModelIsNotFoundException();

            var result = await _repository.Delete(id, cancellationToken);

            return _mapper.Map<TModel>(result);
        }

        public virtual async Task<TModel> Update(TModel model, CancellationToken cancellationToken)
        {
            if (!await IsModelExists(model.Id, cancellationToken)) throw new ModelIsNotFoundException();

            var entity = _mapper.Map<TEntity>(model);

            var result = await _repository.Update(entity, cancellationToken);

            return _mapper.Map<TModel>(result);
        }

        public virtual async Task<bool> IsModelExists(int id, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(id, cancellationToken);

            return result != null;
        }
    }
}
