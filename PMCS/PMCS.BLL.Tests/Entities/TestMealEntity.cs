using PMCS.DAL.Entities;

namespace PMCS.BLL.Tests.Entities
{
    public static class TestMealEntity
    {
        public static MealEntity ValidMealEntity = new MealEntity()
        {
            Id = 1,
            Title = "Test",
            PetId = 1,
            DateTime = DateTime.Today
        };

        public static IEnumerable<MealEntity> ValidMealEntityList = new List<MealEntity>()
        {
            new MealEntity()
            {
                Id = 1,
                Title = "Test1",
                PetId = 1,
                DateTime = DateTime.Today
            },
            new MealEntity()
            {
                Id = 2,
                Title = "Test2",
                PetId = 1,
                DateTime = DateTime.Today
            }
        };

        public static IEnumerable<MealEntity> EmptyMealEntityList = new List<MealEntity>() { };
    }
}
