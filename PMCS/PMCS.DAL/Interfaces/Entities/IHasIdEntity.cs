using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCS.DAL.Interfaces.Entities
{
    public interface IHasIdEntity
    {
        int Id { get; init; }
    }
}
