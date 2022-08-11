using PMCS.API.ViewModels.Vaccine;
using System.Collections;

namespace PMCS.API.Tests.ViewModels.Meal
{
    public class PostValidVaccinesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new PostVaccineViewModel()
            {
                Title = "Vaccine",
                DateTime = DateTime.Today,
                PetId = 2
            } };
            yield return new object[] { new PostVaccineViewModel()
            {
                Title = "COVID-19",
                DateTime = new DateTime(2022, 8, 1),
                PetId = 2
            } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
