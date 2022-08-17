using static PMCS.API.Constants.PetValidationParameters;

namespace PMCS.API.Helpers
{
    public static class PetValidatorHelper
    {
        public static bool IsAValidDate(DateTime? date)
        {
            return date != null && date < DateTime.UtcNow && GetAge(date) <= MaxDurationOfLife;
        }

        private static int? GetAge(DateTime? birthDate)
        {
            bool birthdayCelebratedThisYear = DateTime.UtcNow.DayOfYear - birthDate?.DayOfYear >= 0;
            var age = DateTime.UtcNow.Year - birthDate?.Year;

            if (!birthdayCelebratedThisYear) --age;

            return age;
        }
    }
}
