using Schedule.Application.Core.Models.Pets.Pet;

namespace Schedule.Application.Core.Models.Pets.Vaccine
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }

        public PetShortModel Pet { get; set; }
    }
}
