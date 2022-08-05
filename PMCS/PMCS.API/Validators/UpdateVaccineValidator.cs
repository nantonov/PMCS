using FluentValidation;
using PMCS.API.Resources.Validators;
using PMCS.API.ViewModels.Vaccine;
using static PMCS.API.Constants.VaccineValidationParameters;
using static PMCS.API.Helpers.VaccineValidatorHelper;

namespace PMCS.API.Validators
{
    public class UpdateVaccineValidator : AbstractValidator<UpdateVaccineViewModel>
    {
        public UpdateVaccineValidator()
        {
            RuleFor(x => x.PetId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(UpdateVaccineValidatorResources.IdShouldBeGreaterThanZero);
            RuleFor(x => x.Description)
                .Length(MinDescriptionLength, MaxDescriptionLength)
                .WithMessage(UpdateVaccineValidatorResources.IncorrectDescriptionLength);
            RuleFor(x => x.DateTime)
                .NotEmpty()
                .Must(IsAValidDate)
                .WithMessage(UpdateVaccineValidatorResources.IncorrectDateTime);
            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(MinTitleLength, MaxTitleLength)
                .WithMessage(UpdateVaccineValidatorResources.IncorrectTitleLength);
        }
    }
}
