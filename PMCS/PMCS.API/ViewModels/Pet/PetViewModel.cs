using PMCS.API.ViewModels.Meal;
using PMCS.API.ViewModels.Owner;
using PMCS.API.ViewModels.Vaccine;
using PMCS.API.ViewModels.Walking;

namespace PMCS.API.ViewModels.Pet
{
    public class PetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Info { get; set; }
        public DateTime? BirthDate { get; set; }
        public float? Weight { get; set; }

        public OwnerViewModel Owner { get; set; }
        public IEnumerable<MealViewModel> Meals { get; set; }
        public IEnumerable<WalkingViewModel> Walkings { get; set; }
        public IEnumerable<VaccineViewModel> Vaccines { get; set; }
    }
}
