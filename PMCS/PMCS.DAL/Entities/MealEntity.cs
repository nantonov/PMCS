using PMCS.DAL.Interfaces.Entities;

namespace PMCS.DAL.Entities
{
    public class MealEntity : IHasIdEntity
    {
        public Guid Id { get; init; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }

        public Guid PetId { get; init; }
        public PetEntity Pet { get; init; }
    }
}
