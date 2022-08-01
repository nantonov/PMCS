using static PMCS.API.Constants.PetValidationParameters;

namespace PMCS.API.Validators
{
    public static class PetBirthDateValidation
    {
        public static bool BeAValidDate(DateTime? date)
        {
            return !date.Equals(default(DateTime)) && date < DateTime.Now && GetAge(date, DateTime.Now) <= MaxDurationOfLife;
        }

        private static int? GetAge(DateTime? birthDate, DateTime now)
        {
            bool birthdayCelebratedThisYear = (now.DayOfYear - birthDate?.DayOfYear) >= 0;
            var age = now.Year - birthDate?.Year;

            if (!birthdayCelebratedThisYear) --age;

            return age;
        }
    }
}
