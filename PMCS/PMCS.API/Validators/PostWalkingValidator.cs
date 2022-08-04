using FluentValidation;
using PMCS.API.Resources.Validators;
using PMCS.API.ViewModels.Walking;
using static PMCS.API.Constants.WalkingValidationParameters;
using static PMCS.API.Helpers.WalkingValidatorHelper;

namespace PMCS.API.Validators
{
    public class PostWalkingValidator : AbstractValidator<PostWalkingViewModel>
    {
        public PostWalkingValidator()
        {
            RuleFor(x => x.PetId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(PostWalkingValidatorResources.IdShouldBeGreaterThanZero);
            RuleFor(x => x.Description)
                .Length(MinDescriptionLength, MaxDescriptionLength)
                .WithMessage(PostWalkingValidatorResources.IncorrectDescriptionLength);
            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(MinTitleLength, MaxTitleLength)
                .WithMessage(PostWalkingValidatorResources.IncorrectTitleLength);
            RuleFor(x => x.Stared)
                .NotEmpty()
                .Must(IsAValidDate)
                .WithMessage(PostWalkingValidatorResources.IncorrectDateTime);
            RuleFor(x => x.Finished)
                .NotEmpty()
                .Must(IsAValidDate)
                .WithMessage(PostWalkingValidatorResources.IncorrectDateTime)
                .GreaterThan(x => x.Stared)
                .WithMessage(PostWalkingValidatorResources.FinishedDateTimeMustBeLaterThanStartedOne);
            RuleFor(x => x.Finished)
                .Must((x, finished) => IsWalkingDurationIsValid(x.Stared, finished))
                .WithMessage(PostWalkingValidatorResources.WalkingDurationShouldBeInValidRange);
        }
    }
}
