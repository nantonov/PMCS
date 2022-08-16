namespace PMCS.API.ViewModels.Walking
{
    public class UpdateWalkingViewModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Stared { get; set; }
        public DateTime Finished { get; set; }

        public int PetId { get; set; }
    }
}
