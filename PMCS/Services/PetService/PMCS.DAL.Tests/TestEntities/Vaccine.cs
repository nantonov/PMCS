using PMCS.DAL.Entities;
using static PMCS.DAL.Tests.TestEntities.Pet;

namespace PMCS.DAL.Tests.TestEntities
{
    public static class Vaccine
    {
        public static VaccineEntity ValidVaccineEntity = new VaccineEntity()
        {
            Id = 1,
            Title = "Test",
            PetId = 1,
            Pet = PetEntityForRelatedEntitiesTests
        };

        public static VaccineEntity VaccineEntityWithInexistentId = new VaccineEntity()
        {
            Id = 1000,
            Title = "Test",
            PetId = 1
        };

        public static VaccineEntity VaccineEntityToInsert = new VaccineEntity()
        {
            Id = 4,
            Title = "Inserted",
            PetId = 1,
            Pet = PetEntityForRelatedEntitiesTests
        };

        public static VaccineEntity VaccineEntityToUpdate = new VaccineEntity() { Id = 10, Title = "Old Title", PetId = 1, Pet = PetEntityForRelatedEntitiesTests };

        public static VaccineEntity UpdatedVaccineEntity = new VaccineEntity() { Id = 10, Title = "New Title", PetId = 1, Pet = PetEntityForRelatedEntitiesTests };

        public static IEnumerable<VaccineEntity> ValidVaccineEntityList = new List<VaccineEntity>()
        {
            new VaccineEntity()
            {
                Id = 1,
                Title = "First Entity",
                PetId = 1,
                Pet = ValidPetEntity
            },
            new VaccineEntity()
            {
                Id = 2,
                Title = "Second Entity",
                PetId = 1,
                Pet = ValidPetEntity
            },
        };
    }
}

