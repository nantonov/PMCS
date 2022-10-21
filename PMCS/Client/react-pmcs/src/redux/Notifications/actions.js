import { PUSH_NOTIFICATION, CLEAR_NOTIFICATIONS} from "./constants";

export const pushNotification = (message) => ({ type: PUSH_NOTIFICATION, message: message });
export const clearNotifications = () => ({ type: CLEAR_NOTIFICATIONS });