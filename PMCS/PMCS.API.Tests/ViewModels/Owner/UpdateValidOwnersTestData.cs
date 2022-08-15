using System.Collections;

namespace PMCS.API.Tests.ViewModels.Owner
{
    public class UpdateValidOwnersTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new UpdateOwnerViewModel() { FullName = "Mally Brient" } };
            yield return new object[] { new UpdateOwnerViewModel() { FullName = "Name Surname" } };
            yield return new object[] { new UpdateOwnerViewModel() { FullName = "Full Name" } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
