namespace PMCS.API.Helpers
{
    public static class MealValidatorHelper
    {
        public static bool IsAValidDate(DateTime mealDate)
        {
            return mealDate <= DateTime.UtcNow;
        }
    }
}
