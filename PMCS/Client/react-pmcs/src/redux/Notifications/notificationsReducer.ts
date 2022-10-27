import { CLEAR_NOTIFICATIONS, PUSH_NOTIFICATION } from "./constants";
import * as actions from './actions';

export type NotificationsState = {
    messages: Array<string>
}

let initialState : NotificationsState = {
    messages: [],
};

export type NotificationsActions = ReturnType<typeof actions[keyof typeof actions]>;

const appReducer = (state = initialState, action: NotificationsActions) : NotificationsState => {
    switch (action.type) {
        case PUSH_NOTIFICATION: {
            return {
                ...state, messages: [...state.messages, action.payload]
            };
        }
        case CLEAR_NOTIFICATIONS: {
            return {
                ...state, messages: []
            };
        }
        default:
            return state;
    }
}

export default appReducer;