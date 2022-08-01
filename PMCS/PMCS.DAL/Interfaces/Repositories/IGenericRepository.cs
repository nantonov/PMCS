using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMCS.DAL.Interfaces.Entities;

namespace PMCS.DAL.Interfaces.Repositories
{
    interface IGenericRepository <TEntity> where TEntity : IHasIdEntity
    {
        Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> Get(CancellationToken cancellationToken);
        Task<TEntity> GetById(int id, CancellationToken cancellationToken);
        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> Delete(int id, CancellationToken cancellationToken);
    }
}
