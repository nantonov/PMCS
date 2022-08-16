using PMCS.DLL.Interfaces.Models;

namespace PMCS.DLL.Models
{
    public class MealModel : IHasIdModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }

        public int PetId { get; init; }
        public PetModel Pet { get; init; }
    }
}
