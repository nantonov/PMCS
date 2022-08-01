﻿using FluentValidation;
using PMCS.API.ViewModels.Pet;
using static PMCS.API.Constants.PetValidationParameters;
using static PMCS.API.Validators.PetBirthDateValidation;

namespace PMCS.API.Validators
{
    public class UpdatePetValidator : AbstractValidator<UpdatePetViewModel>
    {
        public UpdatePetValidator()
        {
            RuleFor(x => x.Name).
                Cascade(CascadeMode.Stop).
                NotEmpty().
                Length(MinNameLength, MaxNameLength).
                Matches(NameRegularExpression).
                WithMessage("Invalid pet's name.");
            RuleFor(x => x.Info).
                Cascade(CascadeMode.Stop).
                Length(MinInfoLength, MaxInfoLength).
                WithMessage("Info has invalid length.");
            RuleFor(x => x.BirthDate)
                .Cascade(CascadeMode.Stop)
                .Must(BeAValidDate)
                .WithMessage("Invalid birth date");
            RuleFor(x => x.Weight).
                Cascade(CascadeMode.Stop).
                InclusiveBetween(MinWeight, MaxWeight);
        }

    }
}
