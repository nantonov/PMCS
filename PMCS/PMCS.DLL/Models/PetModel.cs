using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCS.DLL.Models
{
    public class PetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Info { get; set; }
        public DateTime? BirthDate { get; set; }
        public float? Weight { get; set; }

        public int OwnerId { get; set; }
        public OwnerModel Owner { get; set; }
        public IEnumerable<MealModel> Meals { get; set; } = new List<MealModel>();
        public IEnumerable<WalkingModel> Walkings { get; set; } = new List<WalkingModel>();
        public IEnumerable<VaccineModel> Vaccines { get; set; } = new List<VaccineModel>();
    }
}
