using PMCS.API.ViewModels.Pet;

namespace PMCS.API.ViewModels.Vaccine
{
    public class VaccineViewModel
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }

        public PetViewModel Pet { get; set; }
    }
}
