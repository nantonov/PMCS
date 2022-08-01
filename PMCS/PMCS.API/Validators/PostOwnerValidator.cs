using FluentValidation;
using PMCS.API.ViewModels.Owner;
using static PMCS.API.Constants.OwnerValidationParameters;

namespace PMCS.API.Validators
{
    public class PostOwnerValidator : AbstractValidator<PostOwnerViewModel>
    {
        public PostOwnerValidator()
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
