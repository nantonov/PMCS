namespace PMCS.DLL.Models
{
    public class MealModel
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }

        public Guid PetId { get; init; }
        public MealModel Pet { get; init; }
    }
}
