using PMCS.DAL.Interfaces.Entities;

namespace PMCS.DAL.Entities
{
    public class PetEntity : IHasIdEntity
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string? Info { get; set; }
        public DateTime? BirthDate { get; set; }
        public float? Weight { get; set; }

        public int OwnerId { get; init; }
        public OwnerEntity Owner { get; init; }
        public IEnumerable<MealEntity> Meals { get; set; } = new List<MealEntity>();
        public IEnumerable<WalkingEntity> Walkings { get; set; } = new List<WalkingEntity>();
        public IEnumerable<VaccineEntity> Vaccines { get; set; } = new List<VaccineEntity>();
    }
}
