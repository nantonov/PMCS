using PMCS.BLL.Interfaces.Models;

namespace PMCS.BLL.Models
{
    public class PetModel : IHasIdModel
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
