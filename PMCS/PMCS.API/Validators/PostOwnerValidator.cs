using FluentValidation;
using PMCS.API.Resources.Validators;
using PMCS.API.ViewModels.Owner;
using static PMCS.API.Constants.OwnerValidationParameters;

namespace PMCS.API.Validators
{
    public class PostOwnerValidator : AbstractValidator<PostOwnerViewModel>
    {
        public PostOwnerValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .Length(MinNameLength, MaxNameLength)
                .Matches(FullNameRegularExpression)
                .WithMessage(PostOwnerValidatorResources.IncorrectFullName);
        }
    }
}
