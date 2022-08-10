using System.Collections;

namespace PMCS.API.Tests.ViewModels
{
    public class UpdateOwnersWithInvalidFullNamesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new UpdateOwnerViewModel() { FullName = "" } };
            yield return new object[] { new UpdateOwnerViewModel() { FullName = "Lao" } };
            yield return new object[] { new UpdateOwnerViewModel() { FullName = "Jeff R0nald" } };
            yield return new object[] { new UpdateOwnerViewModel() { FullName = "48785566" } };
            yield return new object[] { new UpdateOwnerViewModel() { FullName = "Figuring out that something the length of this name more than thirty five characters" } };
            yield return new object[] { new UpdateOwnerViewModel() { FullName = "@Anton Leonov" } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
