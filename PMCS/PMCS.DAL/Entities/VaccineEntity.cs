using PMCS.DAL.Interfaces.Entities;

namespace PMCS.DAL.Entities
{
    public class VaccineEntity : IHasIdEntity
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }

        public int PetId { get; init; }
        public PetEntity Pet { get; init; }
    }
}
