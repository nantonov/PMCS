import { clearNotifications, pushNotification } from './actions';
import connectionService from '../../Services/connectionService';

export const startReceivingMessages = (connection) => {
    return async (dispatch) => {
        connectionService.startReceivingMessages(connection, (message) => {
            dispatch(pushNotification(message));
        });
    };
};

export const clearMessages = () => {
    return async (dispatch) => {
        dispatch(clearNotifications());
    };
}