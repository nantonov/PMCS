using PMCS.API.ViewModels.Walking;
using System.Collections;

namespace PMCS.API.Tests.ViewModels.Meal
{
    public class PostInvalidWalkingsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new PostWalkingViewModel()
            {
                Title = "Title",
                Stared = DateTime.Today,
                Finished = DateTime.Today.AddDays(1),
                PetId = 1
            } };
            yield return new object[] { new PostWalkingViewModel()
            {
                Title = "Bad meds",
                Stared = DateTime.Today,
                Finished = DateTime.Today.AddMinutes(20),
                PetId = -1
            } };
            yield return new object[] { new PostWalkingViewModel()
            {
                Title = "Title",
                PetId = 0
            } };
            yield return new object[] { new PostWalkingViewModel()
            {
                Title = "Title",
                PetId = 1,
                Stared = DateTime.Today,
                Finished = DateTime.Today.AddSeconds(1)
            } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
