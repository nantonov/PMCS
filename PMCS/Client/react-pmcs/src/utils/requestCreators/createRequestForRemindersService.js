import { toUtcDateTime } from "../dateFormatitng";

export function createRequestToAddReminder(reminder) {
    const request = {
        petId: reminder.petId,
        triggerDateTime: toUtcDateTime(reminder.triggerDateTime),
        notificationMessage: reminder.notificationMessage,
        notificationType: reminder.notificationType,
        actionToRemindType: reminder.actionToRemindType,
    };

    return request;
}

export function createRequestToUpdateReminder(reminder) {
    const request = {
        id: reminder.id,
        triggerDateTime: toUtcDateTime(reminder.triggerDateTime),
        notificationMessage: reminder.notificationMessage,
        notificationType: reminder.notificationType,
        actionToRemindType: reminder.actionToRemindType,
    };

    return request;
}