﻿using FluentValidation;
using Notifications.API.Models.Requests;
using Notifications.BLL.Resources.Constants.Validators;

namespace Notifications.API.Validators
{
    public class EmailRequestValidator : AbstractValidator<SendEmailNotificationViewModel>
    {
        public EmailRequestValidator()
        {
            RuleFor(x => x.ReceiverEmailAddress)
                .EmailAddress()
                .WithMessage(ValidationResources.EmailIsNotVaild)
                .NotEmpty()
                .WithMessage(ValidationResources.EmailMustNotBeEmpty);
            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage(ValidationResources.MessageMustNotBeEmpty);
        }
    }
}
