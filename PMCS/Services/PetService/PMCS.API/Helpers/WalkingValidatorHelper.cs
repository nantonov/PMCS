using static PMCS.API.Constants.WalkingValidationParameters;

namespace PMCS.API.Helpers
{
    public class WalkingValidatorHelper
    {
        public static bool IsAValidDate(DateTime date)
        {
            return date <= DateTime.UtcNow;
        }

        public static bool IsWalkingDurationIsValid(DateTime started, DateTime finished)
        {
            TimeSpan walkingDuration = finished - started;

            return walkingDuration.TotalSeconds > MinWalkingDurationInSeconds && walkingDuration.TotalSeconds < MaxWalkingDurationInSeconds;
        }
    }
}
