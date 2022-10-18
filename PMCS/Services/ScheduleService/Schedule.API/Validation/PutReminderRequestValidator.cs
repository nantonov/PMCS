using FluentValidation;
using Schedule.API.Requests;
using Schedule.API.Resources;
using Schedule.Application.Helpers;

namespace Schedule.API.Application.Validation
{
    public class PutReminderRequestValidator : AbstractValidator<PutReminderRequest>
    {
        public PutReminderRequestValidator()
        {
            RuleFor(x => x.Id).
                NotEmpty().WithMessage(ValidationResources.IdFieldMustNotBeEmpty);

            RuleFor(x => x.NotificationType).
                IsInEnum().WithMessage(ValidationResources.EnumTypeMustExist);

            RuleFor(x => x.ActionToRemindType).
                IsInEnum().WithMessage(ValidationResources.EnumTypeMustExist);

            RuleFor(x => x.NotificationMessage).
                NotEmpty().WithMessage(ValidationResources.MessageMustNotBeEmpty).
                MaximumLength(100).WithMessage(ValidationResources.InvalidMessageLength);

            RuleFor(x => x.TriggerDateTime).
                NotEmpty().WithMessage(ValidationResources.TriggerDateMustNotBeEmpty).
                Must(ValidationHelper.IsAValidDate).WithMessage(ValidationResources.TriggerDateMustBeInFuture);
        }
    }
}
