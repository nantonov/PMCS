namespace PMCS.API.Helpers
{
    public class VaccineValidatorHelper
    {
        public static bool IsAValidDate(DateTime mealDate)
        {
            return mealDate != null && mealDate <= DateTime.UtcNow;
        }
    }
}
