namespace PMCS.API.Helpers
{
    public class VaccineValidatorHelper
    {
        public static bool IsAValidDate(DateTime date)
        {
            return date != null && date <= DateTime.UtcNow;
        }
    }
}
