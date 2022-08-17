namespace PMCS.API.ViewModels.Vaccine
{
    public class PostVaccineViewModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }

        public int PetId { get; set; }
    }
}
