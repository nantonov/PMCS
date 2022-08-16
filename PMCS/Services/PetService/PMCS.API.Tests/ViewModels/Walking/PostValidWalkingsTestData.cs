using PMCS.API.ViewModels.Walking;
using System.Collections;

namespace PMCS.API.Tests.ViewModels.Meal
{
    public class PostValidWalkingsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new PostWalkingViewModel()
            {
                Title = "Walking",
                Stared = DateTime.Today,
                Finished = DateTime.Today.AddMinutes(20),
                PetId = 2
            } };
            yield return new object[] { new PostWalkingViewModel()
            {
                Title = "ParkWalking",
                Stared = new DateTime(2022, 1, 1, 1, 1, 1),
                Finished = new DateTime(2022, 1, 1, 1, 5, 1),
                PetId = 2
            } };
            yield return new object[] { new PostWalkingViewModel()
            {
                Title = "Title",
                Stared = new DateTime(2022, 1, 1, 1, 1, 1),
                Finished = new DateTime(2022, 1, 1, 4, 1, 10),
                PetId = 2
            } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
