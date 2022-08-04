namespace PMCS.API.Constants
{
    public static class PetValidationParameters
    {
        public const int MaxDurationOfLife = 70;
        public const int MaxNameLength = 30;
        public const int MinNameLength = 3;
        public const int MaxInfoLength = 300;
        public const int MinInfoLength = 5;
        public const float MinWeight = 0.05f;
        public const float MaxWeight = 1000.0f;

        public const string NameRegularExpression = "^[a-zA-Z0-9 ]*$";
    }
}
