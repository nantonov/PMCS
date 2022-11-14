using AutoMapper;
using PMCS.BLL.Exceptions;
using PMCS.BLL.Interfaces.Services;
using PMCS.BLL.Models;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;

namespace PMCS.BLL.Services
{
    public class OwnerService : GenericService<OwnerModel, OwnerEntity>, IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _ownerRepository = repository;
        }

        public async Task<OwnerModel> GetByExternalId(int externalId, CancellationToken cancellationToken)
        {
            var entity = await _ownerRepository.GetByExternalId(externalId, cancellationToken);

            if (entity == null) throw new ModelIsNotFoundException();

            return _mapper.Map<OwnerModel>(entity);
        }
    }
}
