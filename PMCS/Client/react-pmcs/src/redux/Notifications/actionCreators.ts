import { clearNotifications, pushNotification } from './actions';
import connectionService from '../../Services/connectionService';
import { AppDispatch } from '../types';
import { NotificationsActions } from './notificationsReducer';
import { HubConnection } from '@microsoft/signalr';
import { Nullable } from '../../utils/types/Nullable';


export const startReceivingMessages = (connection : Nullable<HubConnection>) => {
    return async (dispatch : AppDispatch<NotificationsActions>) => {
        connectionService.startReceivingMessages(connection, (message : string) => {
            dispatch(pushNotification(message));
        });
    };
};

export const clearMessages = () => {
    return async (dispatch : AppDispatch<NotificationsActions>) => {
        dispatch(clearNotifications());
    };
}