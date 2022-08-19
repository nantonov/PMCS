using FluentValidation;
using Notifications.API.Models.Requests;
using Notifications.BLL.Resources.Constants.Validators;

namespace Notifications.API.Validators
{
    public class ClientRequestValidator : AbstractValidator<ClientNotificationRequest>
    {
        public ClientRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage(ValidationResources.UserIdIsNotNull);
            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage(ValidationResources.MessageMustNotBeEmpty);
        }
    }
}
