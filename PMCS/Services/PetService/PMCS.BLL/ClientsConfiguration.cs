namespace PMCS.BLL
{
    public static class ClientsConfiguration
    {
        public const string ScheduleClientName = "Schedule";
        public const string ScheduleServiceAddress = "https://localhost:7064";
        public const int ScheduleClientRetryCount = 3;
        public const int ScheduleSleepDurationInMilliseconds = 100;
    }
}
