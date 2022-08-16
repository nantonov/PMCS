namespace PMCS.API.ViewModels.Walking
{
    public class WalkingShortViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Stared { get; set; }
        public DateTime Finished { get; set; }
    }
}
