using System.Reflection;
using System.Resources;
using FluentValidation;
using PMCS.API.ViewModels.Pet;
using static PMCS.API.Constants.PetValidationParameters;
using static PMCS.API.Validators.PetBirthDateValidation;

namespace PMCS.API.Validators
{
    public class UpdatePetValidator : AbstractValidator<UpdatePetViewModel>
    {
        private ResourceManager resourceManager = new ResourceManager("PMCS.API.Resources.Validators.UpdatePetValidatorResources",
            Assembly.GetExecutingAssembly());
        public UpdatePetValidator()
        {
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
                Cascade(CascadeMode.Stop).
                InclusiveBetween(MinWeight, MaxWeight).
                WithMessage(resourceManager.GetString("Weight"));
        }

    }
}
