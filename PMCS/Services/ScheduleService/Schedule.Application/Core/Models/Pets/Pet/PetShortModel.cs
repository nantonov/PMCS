namespace Schedule.Application.Core.Models.Pets.Pet
{
    public class PetShortModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Info { get; set; }
        public DateTime? BirthDate { get; set; }
        public float? Weight { get; set; }
    }
}
