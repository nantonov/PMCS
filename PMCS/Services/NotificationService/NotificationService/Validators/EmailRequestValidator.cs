using FluentValidation;
using Notifications.API.Models.Requests;
using Notifications.BLL.Resources.Constants.Validators;

namespace Notifications.API.Validators
{
    public class EmailRequestValidator : AbstractValidator<EmailNotificationRequest>
    {
        public EmailRequestValidator()
        {
            RuleFor(x => x.RecieverEmailAddress)
                .EmailAddress()
                .WithMessage(ValidationResources.EmailIsNotVaild)
                .NotEmpty()
                .WithMessage(ValidationResources.EmailMustNotBeEmpty);
            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage(ValidationResources.MessageMustNotBeEmpty);
            RuleFor(x => x.OwnerName)
                .NotEmpty()
                .WithMessage(ValidationResources.NameMustNotBeEmpty);
            RuleFor(x => x.PetName)
                .NotEmpty()
                .WithMessage(ValidationResources.NameMustNotBeEmpty);
        }
    }
}
