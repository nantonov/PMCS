namespace Schedule.Application.Configuration
{
    public static class AuthConfiguration
    {
        public const string Audience = "ScheduleAPI";
        public const string Authority = "https://localhost:5001/";
        public const bool RequireHttpsMetadata = false;
        public const bool ValidateAudience = false;

        public const string ClientId = "client_id";
        public const string ClientSecret = "pmcs-client-secret";

        public const string PetScope = "PetsAPI";
        public const string NotificationScope = "NotificationsAPI";
    }
}
