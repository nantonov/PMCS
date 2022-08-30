using Schedule.Domain.Exceptions;
using Schedule.Domain.SeedWork;

namespace Schedule.Domain.AggregateModels.ReminderAggregate
{
    public class Reminder : Entity, IAggregateRoot
    {
        public TriggerDateTime TriggerDateTime { get; private set; }

        private readonly DateTime _creationDateTime;

        private int _petId;

        public NotificationType NotificationType { get; private set; }
        private int _notificationTypeId;

        private int _userId;

        private string? _description;

        private string _message;

        public ActionToRemindType ActionToRemindType { get; private set; }
        private int _actionToRemindId;

        public ReminderStatus ReminderStatus { get; private set; }
        private int _statusId;

        public Reminder(TriggerDateTime triggerDateTime, int petId, int notificationTypeId, string message, int actionToRemindId,
            int userId, string? description = null)
        {
            TriggerDateTime = triggerDateTime;
            _petId = petId;
            _userId = userId;
            _creationDateTime = DateTime.UtcNow;
            _description = description;

            SetNotificationTypeId(notificationTypeId);
            SetActionToRemindId(actionToRemindId);
            ResetStatus();
            SetMessage(message);
        }

        private void SetActionToRemindId(int actionToRemindId)
        {
            ActionToRemindType.ValidateId(actionToRemindId);

            _actionToRemindId = actionToRemindId;
        }

        private void SetNotificationTypeId(int notificationTypeId)
        {
            NotificationType.ValidateId(notificationTypeId);

            _notificationTypeId = notificationTypeId;
        }

        public string GetMessage => _message;
        public DateTime GetCreationDateTime => _creationDateTime;
        public int GetPetId => _petId;
        public string GetDescription => _description;
        public int GetUserId => _userId;

        public void SetMessage(string value)
        {
            ValidateMessage(value);

            _message = value;
        }

        public void SetPetId(int value) => _petId = value;
        public void SetOwnerId(int value) => _userId = value;

        public void SetEmailNotificationType()
        {
            _notificationTypeId = NotificationType.Email.GetId;
        }

        public void SetPersonalAccountNotificationType()
        {
            _notificationTypeId = NotificationType.PersonalAccount.GetId;
        }

        public void SetActionToRemindToGoForWalk()
        {
            _actionToRemindId = ActionToRemindType.GoForWalk.GetId;

            _description = "Reminds to go for a walk";
        }

        public void SetActionToRemindToFeedPet()
        {
            _actionToRemindId = ActionToRemindType.FeedPet.GetId;

            _description = "Reminds to feed a pet.";
        }

        public void SetActionToRemindToMakeVaccine()
        {
            _actionToRemindId = ActionToRemindType.MakeVaccine.GetId;

            _description = "Reminds to make a vaccine.";
        }

        public void SetStatusToDone()
        {
            _statusId = ReminderStatus.Done.GetId;
        }

        public void ResetStatus()
        {
            _statusId = ReminderStatus.ToDo.GetId;
        }

        private static void ValidateMessage(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new ScheduleDomainException("Message must not be empty.");
        }
    }
}
