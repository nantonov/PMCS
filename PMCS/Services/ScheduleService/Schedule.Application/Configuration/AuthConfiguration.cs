namespace Schedule.Application.Configuration
{
    public static class AuthConfiguration
    {
        public const string Audience = "ScheduleAPI";
        public const string Authority = "https://localhost:5001/";
        public const bool RequireHttpsMetadata = false;
        public const bool ValidateAudience = false;

        public const string ClientId = "pmcs-client-id";
        public const string SwaggerClientId = "swagger-client-id";
        public const string ClientSecret = "client_secret";

        public const string PetScope = "PetAPI";
        public const string NotificationScope = "NotificationsAPI";
        public const string ScheduleScope = "ScheduleAPI";
    }
}
