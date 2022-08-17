namespace PMCS.API.Constants
{
    public static class WalkingValidationParameters
    {
        public const int MinTitleLength = 3;
        public const int MaxTitleLength = 50;
        public const int MinDescriptionLength = 1;
        public const int MaxDescriptionLength = 150;
        public static int MaxWalkingDurationInSeconds = 28800;
        public static int MinWalkingDurationInSeconds = 60;
    }
}
