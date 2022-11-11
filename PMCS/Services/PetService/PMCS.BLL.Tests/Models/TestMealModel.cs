using PMCS.BLL.Models;

namespace PMCS.BLL.Tests.Models
{
    public static class TestMealModel
    {
        public static MealModel ValidMealModel = new MealModel()
        {
            Id = 1,
            Title = "Test",
            PetId = 1,
            DateTime = DateTime.Today
        };

        public static IEnumerable<MealModel> ValidMealModelList = new List<MealModel>()
        {
            new MealModel()
            {
                Id = 1,
                Title = "Test1",
                PetId = 1,
                DateTime = DateTime.Today
            },
            new MealModel()
            {
                Id = 2,
                Title = "Test2",
                PetId = 1,
                DateTime = DateTime.Today
            }
        };

        public static IEnumerable<MealModel> EmptyMealModelList = new List<MealModel>() { };
    }
}
