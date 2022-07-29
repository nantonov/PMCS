using PMCS.API.ViewModels.Pet;

namespace PMCS.API.ViewModels.Owner
{
    public class OwnerViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public IEnumerable<PetViewModel> Pets { get; set; }
    }
}
