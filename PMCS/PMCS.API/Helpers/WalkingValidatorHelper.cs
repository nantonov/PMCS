using static PMCS.API.Constants.WalkingValidationParameters;

namespace PMCS.API.Helpers
{
    public class WalkingValidatorHelper
    {
        public static bool IsAValidDate(DateTime mealDate)
        {
            return mealDate != null && mealDate <= DateTime.UtcNow;
        }

        public static bool IsWalkingDurationIsValid(DateTime started, DateTime finished)
        {
            var walkingDuration = (finished - started).Minutes;

            return walkingDuration > MinWalkingDuration && walkingDuration < MaxWalkingDuration;
        }
    }
}
