using System.Reflection;
using System.Resources;
using FluentValidation;
using PMCS.API.ViewModels.Pet;
using static PMCS.API.Constants.PetValidationParameters;
using static PMCS.API.Validators.PetBirthDateValidation;

namespace PMCS.API.Validators
{
    public class PostPetValidator : AbstractValidator<PostPetViewModel>
    {
        private ResourceManager resourceManager = new ResourceManager("PMCS.API.Resources.Validators.PostPetValidatorResources",
            Assembly.GetExecutingAssembly());
        public PostPetValidator()
        {
            RuleFor(x => x.OwnerId).
                NotEmpty().
                GreaterThan(0).
                WithMessage(resourceManager.GetString("Id"));
            RuleFor(x => x.Name).
                NotEmpty().
                Length(MinNameLength, MaxNameLength).
                Matches(NameRegularExpression).
                WithMessage(resourceManager.GetString("PetName"));
            RuleFor(x => x.Info).
                Length(MinInfoLength, MaxInfoLength).
                WithMessage(resourceManager.GetString("Info"));
            RuleFor(x => x.BirthDate)
                .Must(BeAValidDate)
                .WithMessage(resourceManager.GetString("BirthDate"));
            RuleFor(x => x.Weight).
                InclusiveBetween(MinWeight,MaxWeight).
                WithMessage(resourceManager.GetString("Weight"));
        }
    }
}
