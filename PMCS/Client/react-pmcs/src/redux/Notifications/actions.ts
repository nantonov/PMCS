import { PUSH_NOTIFICATION, CLEAR_NOTIFICATIONS} from "./constants";

export type PushNotificationAction = {
    type: typeof PUSH_NOTIFICATION
    payload: string
};

export type ClearNotificationsAction = {
    type: typeof CLEAR_NOTIFICATIONS
}

export const pushNotification = (message : string) : PushNotificationAction => ({ type: PUSH_NOTIFICATION, payload: message });
export const clearNotifications = () : ClearNotificationsAction => ({ type: CLEAR_NOTIFICATIONS });