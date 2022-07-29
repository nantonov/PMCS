using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCS.DAL.Interfaces.Entities
{
    interface IHasIdEntity
    {
        Guid Id { get;}
    }
}
