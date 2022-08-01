using FluentValidation;
using PMCS.API.ViewModels.Owner;
using static PMCS.API.Constants.OwnerValidationParameters;

namespace PMCS.API.Validators
{
    public class UpdateOwnerValidator : AbstractValidator<UpdateOwnerViewModel>
    {
        public UpdateOwnerValidator()
        {
            RuleFor(x => x.FullName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(MinNameLength, MaxNameLength)
                .Matches(FullNameRegularExpression)
                .WithMessage("Owner's full name is not valid.");
        }
    }
}
