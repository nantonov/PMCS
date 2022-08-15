using PMCS.API.ViewModels.Vaccine;
using System.Collections;

namespace PMCS.API.Tests.ViewModels.Meal
{
    public class UpdateValidVaccinesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new UpdateVaccineViewModel()
            {
                Title = "Vaccines",
                DateTime = DateTime.Today,
                PetId = 2
            } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
