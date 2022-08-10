using PMCS.DAL.Entities;
using static PMCS.DAL.Tests.TestEntities.Pet;

namespace PMCS.DAL.Tests.TestEntities
{
    public static class Meal
    {
        public static MealEntity ValidMealEntity = new MealEntity()
        {
            Id = 1,
            Title = "Test",
            PetId = 1,
            Pet = PetEntityForMealTest
        };

        public static MealEntity MealEntityWithInexistentId = new MealEntity()
        {
            Id = 1000,
            Title = "Test",
            PetId = 1
        };

        public static MealEntity MealEntityToInsert = new MealEntity()
        {
            Id = 4,
            Title = "Inserted",
            PetId = 1,
            Pet = PetEntityForMealTest
        };

        public static MealEntity MealEntityToUpdate = new MealEntity() { Id = 10, Title = "Old Title", PetId = 1, Pet = PetEntityForMealTest };

        public static MealEntity UpdatedMealEntity = new MealEntity() { Id = 10, Title = "New Title", PetId = 1, Pet = PetEntityForMealTest };

        public static IEnumerable<MealEntity> ValidMealEntityList = new List<MealEntity>()
        {
            new MealEntity()
            {
                Id = 1,
                Title = "First Entity",
                PetId = 1,
                Pet = new PetEntity()
                {
                    Id = 1,
                    Name = "For meal",
                    OwnerId = 1,
                    Owner = new OwnerEntity()
                    {
                        FullName = "Test Owner",
                        Id = 1
                    }
                }
            },
            new MealEntity()
            {
                Id = 2,
                Title = "Second Entity",
                PetId = 2,
                Pet = new PetEntity()
                {
                    Id = 2,
                    Name = "For meal",
                    OwnerId = 2,
                    Owner = new OwnerEntity()
                    {
                        FullName = "Test Owner",
                        Id = 2
                    }
                }
            },
        };
    }
}
