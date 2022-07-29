using PMCS.DAL.Interfaces.Entities;

namespace PMCS.DAL.Entities
{
    public class OwnerEntity : IHasIdEntity
    {
        public Guid Id { get; init; }
        public string FullName { get; set; }

        public IEnumerable<PetEntity> Pets { get; set; } = new List<PetEntity>();
    }
}
