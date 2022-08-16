using PMCS.API.ViewModels.Vaccine;
using System.Collections;

namespace PMCS.API.Tests.ViewModels.Meal
{
    public class UpdateInvalidVaccinesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new UpdateVaccineViewModel()
            {
                Title = "",
                DateTime = DateTime.Today,
                PetId = 1
            } };
            yield return new object[] { new UpdateVaccineViewModel()
            {
                Title = "A",
                PetId = -1
            } };
            yield return new object[] { new UpdateVaccineViewModel()
            {
                Title = "Title",
                PetId = 0
            } };
            yield return new object[] { new UpdateVaccineViewModel()
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
