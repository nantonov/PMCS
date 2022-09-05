using FluentValidation;
using Schedule.API.Resources;
using Schedule.Application.Common.Commands;
using Schedule.Application.Helpers;

namespace Schedule.API.Application.Validation
{
    public class PutReminderRequestValidator : AbstractValidator<UpdateReminderCommand>
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
                IsInEnum().WithMessage(ValidationResources.EnumTypeMustExist);
            RuleFor(x => x.TriggerDateTime).
                NotEmpty().WithMessage(ValidationResources.TriggerDateMustNotBeEmpty).
                Must(ValidationHelper.IsAValidDate).WithMessage(ValidationResources.TriggerDateMustBeInFuture);
        }
    }
}
