export function createRequestForRemindersService(reminder) {
    const request = {
        petId: reminder.petId,
        triggerDateTime: reminder.triggerDateTime,
        notificationMessage: reminder.notificationMessage,
        notificationType: reminder.notificationType,
        actionToRemindType: reminder.actionToRemindType,
    };

    return request;
}