using PMCS.API.ViewModels.Meal;
using System.Collections;

namespace PMCS.API.Tests.ViewModels.Meal
{
    public class PostValidMealsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new PostMealViewModel()
            {
                Title = "Snacks",
                DateTime = new DateTime(2022, 1, 1, 1, 1, 1),
                PetId = 1
            } };
            yield return new object[] { new PostMealViewModel()
            {
                Title = "Awesome chips",
                PetId = 1
            } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
