namespace Schedule.Application.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsAValidDate(DateTime date) => date > DateTime.UtcNow;
    }
}
