using PMCS.DAL.Entities;

namespace PMCS.DAL.Tests.TestEntities
{
    public static class Pet
    {
        public static PetEntity ValidPetEntity = new PetEntity()
        {
            Id = 1,
            Name = "Test"
        };

        public static PetEntity PetEntityWithInexistentId = new PetEntity()
        {
            Id = 1000,
            Name = "Test"
        };

        public static PetEntity PetEntityToDelete = new PetEntity()
        {
            Id = 1,
            Name = "First"
        };

        public static PetEntity PetEntityToInsert = new PetEntity()
        {
            Id = 4,
            Name = "Inserted"
        };

        public static IEnumerable<PetEntity> ValidPetEntityList = new List<PetEntity>()
        {
            new PetEntity()
            {
                Id = 1,
                Name = "First Entity"
            },
            new PetEntity()
            {
                Id = 2,
                Name = "Second Entity"
            },
            new PetEntity()
            {
                Id = 3,
                Name = "Third Entity"
            }
        };
    }
}
