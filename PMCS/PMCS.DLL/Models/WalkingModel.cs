namespace PMCS.DLL.Models
{
    public class WalkingModel
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Stared { get; set; }
        public DateTime Finished { get; set; }

        public Guid PetId { get; init; }
        public PetModel Pet { get; init; }
    }
}
