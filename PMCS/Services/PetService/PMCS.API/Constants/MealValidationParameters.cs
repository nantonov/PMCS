namespace PMCS.API.Constants
{
    public class MealValidationParameters
    {
        public const int MinTitleLength = 3;
        public const int MaxTitleLength = 50;
        public const int MinDescriptionLength = 1;
        public const int MaxDescriptionLength = 100;

        public const string TitleRegularExpression = "^[a-zA-Z0-9 ]*$";
    }
}
