using PMCS.DAL.Interfaces.Entities;

namespace PMCS.DAL.Entities
{
    public class WalkingEntity : IHasIdEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Stared { get; set; }
        public DateTime Finished { get; set; }

        public int PetId { get; init; }
        public PetEntity Pet { get; init; }
    }
}
