using System.Reflection;
using System.Resources;
using FluentValidation;
using PMCS.API.ViewModels.Owner;
using static PMCS.API.Constants.OwnerValidationParameters;

namespace PMCS.API.Validators
{
    public class PostOwnerValidator : AbstractValidator<PostOwnerViewModel>
    {
        private ResourceManager resourceManager = new ResourceManager("PMCS.API.Resources.Validators.PostOwnerValidatorResources",
            Assembly.GetExecutingAssembly());

        public PostOwnerValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .Length(MinNameLength, MaxNameLength)
                .Matches(FullNameRegularExpression)
                .WithMessage(resourceManager.GetString("FullName"));
        }
    }
}
