using PMCS.API.ViewModels.Walking;
using System.Collections;

namespace PMCS.API.Tests.ViewModels.Meal
{
    public class UpdateValidWalkingsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new UpdateWalkingViewModel()
            {
                Title = "Vaccines",
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
