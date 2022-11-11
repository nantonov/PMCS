using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Exceptions;
using PMCS.DLL.Interfaces.Services;
using PMCS.DLL.Models;

namespace PMCS.DLL.Services
{
    public class OwnerService : GenericService<OwnerModel, OwnerEntity>, IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository repository, IMapper mapper) : base(repository, mapper)
        {
            ArgumentNullException.ThrowIfNull(repository);

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
