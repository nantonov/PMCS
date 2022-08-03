﻿using FluentValidation;
using Microsoft.Extensions.Localization;
using PMCS.API.ViewModels.Owner;
using PMCS.API.ViewModels.Pet;
using static PMCS.API.Constants.PetValidationParameters;
using static PMCS.API.Validators.PetBirthDateValidation;

namespace PMCS.API.Validators
{
    public class PostPetValidator : AbstractValidator<PostPetViewModel>
    {
        public PostPetValidator(IStringLocalizer<PostPetViewModel> localizer)
        {
            RuleFor(x => x.OwnerId).
                NotEmpty().
                GreaterThan(0).
                WithMessage(x=>localizer["Id"]); ;
            RuleFor(x => x.Name).
                NotEmpty().
                Length(MinNameLength, MaxNameLength).
                Matches(NameRegularExpression).
                WithMessage(x=>localizer["PetName"]);
            RuleFor(x => x.Info).
                Length(MinInfoLength, MaxInfoLength).
                WithMessage(x=>localizer["Info"]);
            RuleFor(x => x.BirthDate)
                .Must(BeAValidDate)
                .WithMessage(x=>localizer["BirthDate"]);
            RuleFor(x => x.Weight).
                InclusiveBetween(MinWeight,MaxWeight).
                WithMessage(x=>localizer["Weight"]);
        }
    }
}
