using static PMCS.API.Constants.PetValidationParameters;

namespace PMCS.API.Validators
{
    public static class PetBirthDateValidation
    {
        public static bool BeAValidDate(DateTime? date)
        {
            return date!=null && date < DateTime.Now && GetAge(date) <= MaxDurationOfLife;
        }

        private static int? GetAge(DateTime? birthDate)
        {
            bool birthdayCelebratedThisYear = (DateTime.Now.DayOfYear - birthDate?.DayOfYear) >= 0;
            var age = DateTime.Now.Year - birthDate?.Year;

            if (!birthdayCelebratedThisYear) --age;

            return age;
        }
    }
}
