using FluentValidation;
using Microsoft.Extensions.Localization;
using PMCS.API.ViewModels.Owner;
using static PMCS.API.Constants.OwnerValidationParameters;

namespace PMCS.API.Validators
{
    public class PostOwnerValidator : AbstractValidator<PostOwnerViewModel>
    {
        public PostOwnerValidator(IStringLocalizer<PostOwnerViewModel> localizer)
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .Length(MinNameLength, MaxNameLength)
                .Matches(FullNameRegularExpression)
                .WithMessage(x => localizer["FullName"]);
        }
    }
}
