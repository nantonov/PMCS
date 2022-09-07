using Schedule.Application.Core.Models.Pets.Owner;

namespace Schedule.Application.Core.Models.Pets.Pet
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Info { get; set; }
        public DateTime? BirthDate { get; set; }
        public float? Weight { get; set; }

        public OwnerShortViewModel Owner { get; set; }
        public IEnumerable<Meal.Meal> Meals { get; set; }
        public IEnumerable<Walking.Walking> Walkings { get; set; }
        public IEnumerable<Vaccine.Vaccine> Vaccines { get; set; }
    }
}
