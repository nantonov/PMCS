import { CLEAR_NOTIFICATIONS, PUSH_NOTIFICATION } from "./constants";

let initialState = {
    messages: [],
};

const appReducer = (state = initialState, action) => {
    switch (action.type) {
        case PUSH_NOTIFICATION: {
            return {
                ...state, messages: [...state.messages, action.message]
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