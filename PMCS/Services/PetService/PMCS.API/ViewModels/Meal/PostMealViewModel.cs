namespace PMCS.API.ViewModels.Meal
{
    public class PostMealViewModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }

        public int PetId { get; set; }
    }
}
