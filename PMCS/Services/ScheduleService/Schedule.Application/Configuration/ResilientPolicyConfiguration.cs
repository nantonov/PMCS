namespace Schedule.Application.Configuration
{
    public static class ResilientPolicyConfiguration
    {
        public const int ErrorsAmountBeforeBreaking = 3;
        public const int BreakingDurationInSeconds = 20;
        public const int RetryCount = 3;
    }
}
