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
                DateTime = new DateTime(2022, 1, 1, 1, 1, 1),
                PetId = 2
            } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
