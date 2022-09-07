namespace Schedule.Application.Core.Models.Pets.Walking
{
    public class PostWalkingRequest
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Stared { get; set; }
        public DateTime Finished { get; set; }

        public int PetId { get; set; }
    }
}
