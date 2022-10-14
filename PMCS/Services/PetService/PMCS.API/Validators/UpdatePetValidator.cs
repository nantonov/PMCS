using FluentValidation;
using PMCS.API.Resources.Validators;
using PMCS.API.ViewModels.Pet;
using static PMCS.API.Constants.PetValidationParameters;
using static PMCS.API.Helpers.PetValidatorHelper;

namespace PMCS.API.Validators
{
    public class UpdatePetValidator : AbstractValidator<UpdatePetViewModel>
    {
        public UpdatePetValidator()
        {
            RuleFor(x => x.Name).
                NotEmpty().
                Length(MinNameLength, MaxNameLength).
                Matches(NameRegularExpression).
                WithMessage(UpdatePetValidatorResources.IncorrectName);
            RuleFor(x => x.Info).
                MaximumLength(MaxInfoLength).
                WithMessage(UpdatePetValidatorResources.IncorrectInfoLength);
            RuleFor(x => x.BirthDate)
                .Must(IsAValidDate)
                .WithMessage(UpdatePetValidatorResources.IncorrectBirthDate);
            RuleFor(x => x.Weight).
                InclusiveBetween(MinWeight, MaxWeight).
                WithMessage(UpdatePetValidatorResources.WeightShouldBeWithinValidRange);
            RuleFor(x => x.OwnerId).
                NotEmpty().
                GreaterThan(0).
                WithMessage(UpdatePetValidatorResources.IdShouldBeGreaterThanZero);
        }

    }
}
