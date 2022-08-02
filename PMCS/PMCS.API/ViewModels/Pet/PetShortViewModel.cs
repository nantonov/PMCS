namespace PMCS.API.ViewModels.Pet
{
    public class PetShortViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Info { get; set; }
        public DateTime? BirthDate { get; set; }
        public float? Weight { get; set; }
    }
}
