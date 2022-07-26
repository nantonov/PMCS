﻿using FluentValidation;
using PMCS.API.Resources.Validators;
using PMCS.API.ViewModels.Owner;
using static PMCS.API.Constants.OwnerValidationParameters;

namespace PMCS.API.Validators
{
    public class UpdateOwnerValidator : AbstractValidator<UpdateOwnerViewModel>
    {
        public UpdateOwnerValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .Length(MinNameLength, MaxNameLength)
                .Matches(FullNameRegularExpression)
                .WithMessage(UpdateOwnerValidatorResources.IncorrectFullName);
        }
    }
}
