import { ActionToRemindType, NotificationType } from "../../../Enums/reminderEnums";

export interface IUpdateReminderRequest {
    id: number;
    triggerDateTime: string;
    notificationMessage: string;
    notificationType: NotificationType;
    actionToRemindType: ActionToRemindType;
}