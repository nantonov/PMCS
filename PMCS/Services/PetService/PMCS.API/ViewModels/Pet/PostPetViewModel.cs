namespace PMCS.API.ViewModels.Pet
{
    public class PostPetViewModel
    {
        public string Name { get; set; }
        public string? Info { get; set; }
        public DateTime? BirthDate { get; set; }
        public float? Weight { get; set; }

        public int OwnerId { get; set; }
    }
}
