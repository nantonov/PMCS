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
                WithMessage(PostPetValidatorResources.Name);
            RuleFor(x => x.Info).
                Length(MinInfoLength, MaxInfoLength).
                WithMessage(PostPetValidatorResources.Info);
            RuleFor(x => x.BirthDate)
                .Must(IsAValidDate)
                .WithMessage(PostPetValidatorResources.BirthDate);
            RuleFor(x => x.Weight).
                Cascade(CascadeMode.Stop).
                InclusiveBetween(MinWeight, MaxWeight).
                WithMessage(PostPetValidatorResources.Weight);
        }

    }
}
