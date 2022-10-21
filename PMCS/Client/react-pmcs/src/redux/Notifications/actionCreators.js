import { clearNotifications, pushNotification } from './actions';

export const notify = (notification) => {
    return async (dispatch) => {
        dispatch(pushNotification(notification));
    };
};

export const clearMessages = () => {
    return async (dispatch) => {
        dispatch(clearNotifications());
    };
}