﻿using FluentValidation;
using PMCS.API.Resources.Validators;
using PMCS.API.ViewModels.Meal;
using static PMCS.API.Constants.MealValidationParameters;
using static PMCS.API.Helpers.MealValidatorHelper;

namespace PMCS.API.Validators
{
    public class PostMealValidator : AbstractValidator<PostMealViewModel>
    {
        public PostMealValidator()
        {
            RuleFor(x => x.PetId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(PostMealValidatorResources.IdShouldBeGreaterThanZero);
            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(MinTitleLength, MaxTitleLength)
                .Matches(TitleRegularExpression)
                .WithMessage(PostMealValidatorResources.IncorrectTitle);
            RuleFor(x => x.Description)
                .Length(MinDescriptionLength, MaxDescriptionLength)
                .WithMessage(PostMealValidatorResources.IncorrectDescriptionLength);
            RuleFor(x => x.DateTime)
                .Must(IsAValidDate)
                .WithMessage(PostMealValidatorResources.IncorrectDateTime);
        }
    }
}
