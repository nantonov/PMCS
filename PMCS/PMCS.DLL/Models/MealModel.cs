namespace PMCS.DLL.Models
{
    public class MealModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }

        public int PetId { get; init; }
        public MealModel Pet { get; init; }
    }
}
