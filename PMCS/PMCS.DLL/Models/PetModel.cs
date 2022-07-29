using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCS.DLL.Models
{
    public class PetModel
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string? Info { get; set; }
        public DateTime? BirthDate { get; set; }
        public float? Weight { get; set; }

        public Guid OwnerId { get; init; }
        public OwnerModel Owner { get; init; }
        public IEnumerable<MealModel> Meals { get; set; } = new List<MealModel>();
        public IEnumerable<WalkingModel> Walkings { get; set; } = new List<WalkingModel>();
    }
}
