using PMCS.DAL.Interfaces.Entities;

namespace PMCS.DAL.Entities
{
    public class PetEntity : IHasIdEntity
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string? Info { get; set; }
        public DateTime? BirthDate { get; set; }
        public float? Weight { get; set; }
        public Guid OwnerId { get; init; }
        public OwnerEntity Owner { get; init; }
        public IEnumerable<MealEntity> Meals { get; set; }
        public IEnumerable<WalkingEntity> Walkings { get; set; }
    }
}
