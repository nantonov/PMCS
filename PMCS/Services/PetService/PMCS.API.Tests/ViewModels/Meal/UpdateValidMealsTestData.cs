using PMCS.API.ViewModels.Meal;
using System.Collections;

namespace PMCS.API.Tests.ViewModels.Meal
{
    public class UpdateValidMealsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new UpdateMealViewModel()
            {
                Title = "Snacks",
                DateTime = DateTime.Today,
                PetId = 1
            } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
