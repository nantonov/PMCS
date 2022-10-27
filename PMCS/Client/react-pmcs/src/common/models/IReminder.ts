import { ActionToRemindType, NotificationType, Status } from "../../Enums/reminderEnums";

export interface IReminder {
    id: number;
    triggerDateTime: string;
    description: string;
    notificationMessage: string;
    isTriggered: boolean;
    remainingTimePercentageBeforeTriggering: number;
    lastModified: string;
    notificationType: NotificationType;
    actionToRemindType: ActionToRemindType;
    status: Status;
}