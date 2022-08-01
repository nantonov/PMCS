namespace PMCS.API.ViewModels.Vaccine
{
    public class PostVaccineViewModel
    {
        public int Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }

        public int PetId { get; set; }
    }
}
