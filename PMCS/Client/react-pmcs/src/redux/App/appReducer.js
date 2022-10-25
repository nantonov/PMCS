import {SET_INITIALIZED, SET_HUB_CONNECTION} from './constants';

let initialState = {
    isInitialized: false,
    hubConnection: null
};

const appReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_INITIALIZED: {
            return {
                ...state, isInitialized: true
            };
        }
        case SET_HUB_CONNECTION: {
            return {
                ...state, hubConnection: action.connection
            }
        }
        default:
            return state;
    }
}

export default appReducer;