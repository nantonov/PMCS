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
                WithMessage(PostPetValidatorResources.IncorrectName);
            RuleFor(x => x.Info).
                Length(MinInfoLength, MaxInfoLength).
                WithMessage(PostPetValidatorResources.IncorrectInfoLength);
            RuleFor(x => x.BirthDate)
                .Must(IsAValidDate)
                .WithMessage(PostPetValidatorResources.IncorrectBirthDate);
            RuleFor(x => x.Weight).
                Cascade(CascadeMode.Stop).
                InclusiveBetween(MinWeight, MaxWeight).
                WithMessage(PostPetValidatorResources.WeightShouldBeWithinValidRange);
        }

    }
}
