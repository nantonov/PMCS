using PMCS.API.ViewModels.Pet;

namespace PMCS.API.ViewModels.Walking
{
    public class WalkingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Stared { get; set; }
        public DateTime Finished { get; set; }

        public PetViewModel Pet { get; set; }
    }
}
