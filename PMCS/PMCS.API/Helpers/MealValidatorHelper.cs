namespace PMCS.API.Helpers
{
    public static class MealValidatorHelper
    {
        public static bool IsAValidDate(DateTime mealDate)
        {
            return mealDate != null && mealDate <= DateTime.UtcNow;
        }
    }
}
