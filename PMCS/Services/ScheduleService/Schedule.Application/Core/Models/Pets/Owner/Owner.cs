using Schedule.Application.Core.Models.Pets.Pet;

namespace Schedule.Application.Core.Models.Pets.Owner
{
    public class Owner
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public IEnumerable<PetShortModel> Pets { get; set; }
    }
}
