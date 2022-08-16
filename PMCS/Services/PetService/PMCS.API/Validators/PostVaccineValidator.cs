using FluentValidation;
using PMCS.API.Resources.Validators;
using PMCS.API.ViewModels.Vaccine;
using static PMCS.API.Constants.VaccineValidationParameters;
using static PMCS.API.Helpers.VaccineValidatorHelper;

namespace PMCS.API.Validators
{
    public class PostVaccineValidator : AbstractValidator<PostVaccineViewModel>
    {
        public PostVaccineValidator()
        {
            RuleFor(x => x.PetId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(PostVaccineValidatorResources.IdShouldBeGreaterThanZero);
            RuleFor(x => x.Description)
                .Length(MinDescriptionLength, MaxDescriptionLength)
                .WithMessage(PostVaccineValidatorResources.IncorrectDescriptionLength);
            RuleFor(x => x.DateTime)
                .NotEmpty()
                .Must(IsAValidDate)
                .WithMessage(PostVaccineValidatorResources.IncorrectDateTime);
            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(MinTitleLength, MaxTitleLength)
                .WithMessage(PostVaccineValidatorResources.IncorrectTitleLength);
        }
    }
}
