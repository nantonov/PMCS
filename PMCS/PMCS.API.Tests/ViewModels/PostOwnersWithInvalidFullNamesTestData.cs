using System.Collections;

namespace PMCS.API.Tests.ViewModels
{
    public class PostOwnersWithInvalidFullNamesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new PostOwnerViewModel() { FullName = "" } };
            yield return new object[] { new PostOwnerViewModel() { FullName = "Lao" } };
            yield return new object[] { new PostOwnerViewModel() { FullName = "Jeff R0nald" } };
            yield return new object[] { new PostOwnerViewModel() { FullName = "48785566" } };
            yield return new object[] { new PostOwnerViewModel() { FullName = "Figuring out that something the length of this name more than thirty five characters" } };
            yield return new object[] { new PostOwnerViewModel() { FullName = "@Anton Leonov" } };
            yield return new object[] { new PostOwnerViewModel() { FullName = "Test Name." } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
