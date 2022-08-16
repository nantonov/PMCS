using PMCS.API.ViewModels.Meal;
using System.Collections;

namespace PMCS.API.Tests.ViewModels.Meal
{
    public class UpdateInvalidMealsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new UpdateMealViewModel()
            {
                Title = "",
                DateTime = DateTime.Today,
                PetId = 1
            } };
            yield return new object[] { new UpdateMealViewModel()
            {
                Title = "Awesome chips",
                PetId = -1
            } };
            yield return new object[] { new UpdateMealViewModel()
            {
                Title = "Title",
                PetId = 0
            } };
            yield return new object[] { new UpdateMealViewModel()
            {
                Title = "Title",
                PetId = 1,
                DateTime = DateTime.Now.AddMinutes(1)
            } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
