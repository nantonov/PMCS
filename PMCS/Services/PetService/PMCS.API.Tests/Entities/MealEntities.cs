using PMCS.DAL.Entities;

namespace PMCS.API.Tests.Entities
{
    public static class MealEntities
    {
        public static PetEntity PetEntityForRelatedEntitiesTests = new PetEntity()
        {
            Id = 1,
            Name = "Testful",
            Owner = new OwnerEntity() { Id = 1, FullName = "Test Test" },
            OwnerId = 1
        };

        public static MealEntity ValidMealEntity = new MealEntity()
        {
            Id = 1,
            Title = "Test Meal",
            PetId = 1
        };

        public static MealEntity MealEntityWithInvalidId = new MealEntity()
        {
            Id = 999,
            Title = "Test Meal",
            PetId = 1
        };

        public static IEnumerable<MealEntity> ValidMealEntityList = new List<MealEntity>()
        {
            new MealEntity()
            {
                Id = 4,
                Title = "First Meal",
                PetId = 1
            },
            new MealEntity()
            {
                Id = 3,
                Title = "Second Meal",
                PetId = 1
            }
        };
    }
}
