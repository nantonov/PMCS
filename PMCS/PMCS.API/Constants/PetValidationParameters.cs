namespace PMCS.API.Constants
{
    public static class PetValidationParameters
    {
        public const int MaxDurationOfLife = 70;
        public const int MaxNameLength = 3;
        public const int MinNameLength = 30;
        public const int MaxInfoLength = 5;
        public const int MinInfoLength = 300;
        public const float MinWeight = 0.05f;
        public const float MaxWeight = 1000.0f;

        public const string NameRegularExpression = "^[a-zA-Z0-9 ]*$";
    }
}
