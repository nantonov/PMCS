import { ActionToRemindType, NotificationType } from "../../../Enums/reminderEnums";

export interface ICreateReminderRequest {
    triggerDateTime: string;
    notificationMessage: string;
    notificationType: NotificationType;
    actionToRemindType: ActionToRemindType;
}