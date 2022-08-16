using PMCS.API.ViewModels.Vaccine;
using System.Collections;

namespace PMCS.API.Tests.ViewModels.Meal
{
    public class PostInvalidVaccinesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new PostVaccineViewModel()
            {
                Title = "",
                DateTime = DateTime.Today,
                PetId = 1
            } };
            yield return new object[] { new PostVaccineViewModel()
            {
                Title = "Bad meds",
                PetId = -1
            } };
            yield return new object[] { new PostVaccineViewModel()
            {
                Title = "Title",
                PetId = 0
            } };
            yield return new object[] { new PostVaccineViewModel()
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
