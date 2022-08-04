using FluentValidation;
using PMCS.API.Resources.Validators;
using PMCS.API.ViewModels.Meal;
using static PMCS.API.Constants.MealValidationParameters;
using static PMCS.API.Helpers.MealValidatorHelper;

namespace PMCS.API.Validators
{
    public class UpdateMealValidator : AbstractValidator<UpdateMealViewModel>
    {
        public UpdateMealValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(MinTitleLength, MaxTitleLength)
                .Matches(TitleRegularExpression)
                .WithMessage(PostMealValidatorResources.IncorrectTitle);
            RuleFor(x => x.Description)
                .Length(MinDescriptionLength, MaxDescriptionLength)
                .WithMessage(PostMealValidatorResources.IncorrectDescriptionLength);
            RuleFor(x => x.DateTime)
                .NotEmpty()
                .Must(IsAValidDate)
                .WithMessage(PostMealValidatorResources.IncorrectDateTime);
        }
    }
}
