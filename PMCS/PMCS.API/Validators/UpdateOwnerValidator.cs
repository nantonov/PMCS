using FluentValidation;
using Microsoft.Extensions.Localization;
using PMCS.API.ViewModels.Owner;
using static PMCS.API.Constants.OwnerValidationParameters;

namespace PMCS.API.Validators
{
    public class UpdateOwnerValidator : AbstractValidator<UpdateOwnerViewModel>
    {
        public UpdateOwnerValidator(IStringLocalizer<UpdateOwnerViewModel> localizer)
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .Length(MinNameLength, MaxNameLength)
                .Matches(FullNameRegularExpression)
                .WithMessage(localizer["PetName"]);
        }
    }
}
