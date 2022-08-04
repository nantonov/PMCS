using FluentValidation;
using PMCS.API.Resources.Validators;
using PMCS.API.ViewModels.Walking;
using static PMCS.API.Constants.WalkingValidationParameters;
using static PMCS.API.Helpers.WalkingValidatorHelper;

namespace PMCS.API.Validators
{
    public class UpdateWalkingValidator : AbstractValidator<UpdateWalkingViewModel>
    {
        public UpdateWalkingValidator()
        {
            RuleFor(x => x.Description)
                .Length(MinDescriptionLength, MaxDescriptionLength)
                .WithMessage(UpdateWalkingValidatorResources.IncorrectDescriptionLength);
            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(MinTitleLength, MaxTitleLength)
                .WithMessage(UpdateWalkingValidatorResources.IncorrectTitleLength);
            RuleFor(x => x.Stared)
                .NotEmpty()
                .Must(IsAValidDate)
                .WithMessage(UpdateWalkingValidatorResources.IncorrectDateTime);
            RuleFor(x => x.Finished)
                .NotEmpty()
                .Must(IsAValidDate)
                .WithMessage(UpdateWalkingValidatorResources.IncorrectDateTime)
                .GreaterThan(x => x.Stared)
                .WithMessage(UpdateWalkingValidatorResources.FinishedDateTimeMustBeLaterThanStartedOne);
            RuleFor(x => x.Finished)
                .Must((x, finished) => IsWalkingDurationIsValid(x.Stared, finished))
                .WithMessage(UpdateWalkingValidatorResources.WalkingDurationShouldBeInValidRange);
        }
    }
}
