using PMCS.DAL.Entities;

namespace PMCS.API.Tests.Entities
{
    public static class VaccineEntities
    {
        public static PetEntity PetEntityForRelatedEntitiesTests = new PetEntity()
        {
            Id = 2,
            Name = "Testful",
            Owner = new OwnerEntity() { Id = 2, FullName = "Test Test" },
            OwnerId = 2
        };

        public static VaccineEntity ValidVaccineEntity = new VaccineEntity()
        {
            Id = 1,
            Title = "Test",
            PetId = 2
        };

        public static VaccineEntity ValidVaccineWithInvalidId = new VaccineEntity()
        {
            Id = 999,
            Title = "Test",
            PetId = 2
        };

        public static IEnumerable<VaccineEntity> ValidVaccineEntityList = new List<VaccineEntity>()
        {
            new VaccineEntity()
            {
                Id = 4,
                Title = "Test",
                PetId = 2
            },
            new VaccineEntity()
            {
                Id = 3,
                Title = "Test",
                PetId = 2
            }
        };
    }
}
