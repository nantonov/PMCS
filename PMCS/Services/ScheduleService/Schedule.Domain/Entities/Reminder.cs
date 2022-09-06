using Schedule.Domain.Core.Constants;
using Schedule.Domain.Core.Exceptions;
using Schedule.Domain.Core.Utility;
using Schedule.Domain.Enums;
using Schedule.Domain.Events;
using Schedule.Domain.SeedWork;

namespace Schedule.Domain.Entities
{
    public class Reminder : Entity
    {
        public int PetId { get; private set; }
        public int UserId { get; private set; }
        public DateTime LastModified { get; private set; }
        public string Description { get; private set; }
        public string NotificationMessage { get; private set; }
        public bool IsTriggered { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public ActionToRemindType ActionToRemindType { get; private set; }
        public ExecutionStatus Status { get; private set; }

        private DateTime _triggerDateTime;
        public DateTime TriggerDateTime
        {
            get => _triggerDateTime;

            private set
            {
                if (value < DateTime.Now)
                    throw new ScheduleDomainException("The date time can't be triggered in past.");

                _triggerDateTime = value;
            }
        }

        public Reminder(DateTime triggerDateTime, int petId, int userId, string message, NotificationType notificationType,
            ActionToRemindType actionToRemindType)
        {
            Ensure.NotEmpty(triggerDateTime, "Trigger DateTime is required.", nameof(triggerDateTime));
            Ensure.NotEmpty(message, "Message is required", nameof(message));
            Ensure.IsGreaterThanZero(petId, "PetId is required", nameof(petId));
            Ensure.IsGreaterThanZero(userId, "UserId is required", nameof(userId));

            SetActionToRemind(actionToRemindType);

            TriggerDateTime = triggerDateTime;
            NotificationMessage = message;
            NotificationType = notificationType;
            PetId = petId;
            UserId = userId;
            IsTriggered = false;

            ResetStatus();
        }

        private Reminder() { }

        public void Update(DateTime triggerDateTime, string message, NotificationType notificationType, ActionToRemindType actionToRemindType)
        {
            Ensure.NotEmpty(triggerDateTime, "Trigger DateTime is required.", nameof(triggerDateTime));
            Ensure.NotEmpty(message, "Message is required", nameof(message));

            SetActionToRemind(actionToRemindType);

            TriggerDateTime = triggerDateTime;
            NotificationType = notificationType;
            NotificationMessage = message;
        }

        public void Triggered()
        {
            if (TriggerDateTime <= DateTime.UtcNow)
                throw new ScheduleDomainException("Trigger date time hasn't come yet.");

            IsTriggered = true;

            AddReminderTriggeredDomainEvent();
        }

        public void SetStatusAsDone()
        {
            Status = ExecutionStatus.Done;
            IsTriggered = true;

            UpdateLastModifiedDate();
        }

        public void ResetStatus()
        {
            Status = ExecutionStatus.ToDo;

            UpdateLastModifiedDate();
        }

        private void UpdateLastModifiedDate()
        {
            LastModified = DateTime.UtcNow;
        }

        private void SetActionToRemindAsToGoForWalk()
        {
            ActionToRemindType = ActionToRemindType.GoForWalk;

            Description = ReminderDescriptionMessages.GoForAWalk;
        }

        private void SetActionToRemindAsToFeedPet()
        {
            ActionToRemindType = ActionToRemindType.FeedPet;

            Description = ReminderDescriptionMessages.FeedPet;
        }

        private void SetActionToRemindAsToMakeVaccine()
        {
            ActionToRemindType = ActionToRemindType.MakeVaccine;

            Description = ReminderDescriptionMessages.MakeVaccine;
        }

        private void SetActionToRemind(ActionToRemindType type)
        {
            switch (type)
            {
                case ActionToRemindType.GoForWalk:
                    {
                        SetActionToRemindAsToGoForWalk();
                        break;
                    }
                case ActionToRemindType.FeedPet:
                    {
                        SetActionToRemindAsToFeedPet();
                        break;
                    }
                case ActionToRemindType.MakeVaccine:
                    {
                        SetActionToRemindAsToMakeVaccine();
                        break;
                    }
                default: throw new ScheduleDomainException("Such type of enum doesn't exist.");
            }
        }

        private void AddReminderTriggeredDomainEvent()
        {
            var reminderTriggeredDomainEvent = new ReminderTriggeredDomainEvent(this);

            this.AddDomainEvent(reminderTriggeredDomainEvent);
        }
    }
}
