using FluentValidation;
using Schedule.API.Requests;
using Schedule.API.Resources;
using Schedule.Application.Helpers;
using Schedule.Domain.Enums;

namespace Schedule.API.Application.Validation
{
    public class PutReminderRequestValidator : AbstractValidator<PutReminderRequest>
    {
        public PutReminderRequestValidator()
        {
            RuleFor(x => x.Id).
                NotEmpty().WithMessage(ValidationResources.IdFieldMustNotBeEmpty);

            RuleFor(x => x.NotificationType).
                IsEnumName(typeof(NotificationType), false).WithMessage(ValidationResources.EnumTypeMustExist);

            RuleFor(x => x.ActionToRemindType).
                IsEnumName(typeof(ActionToRemindType), false).WithMessage(ValidationResources.EnumTypeMustExist);

            RuleFor(x => x.NotificationMessage).
                NotEmpty().WithMessage(ValidationResources.MessageMustNotBeEmpty).
                MaximumLength(100).WithMessage(ValidationResources.InvalidMessageLength);

            RuleFor(x => x.TriggerDateTime).
                NotEmpty().WithMessage(ValidationResources.TriggerDateMustNotBeEmpty).
                Must(ValidationHelper.IsAValidDate).WithMessage(ValidationResources.TriggerDateMustBeInFuture);
        }
    }
}
