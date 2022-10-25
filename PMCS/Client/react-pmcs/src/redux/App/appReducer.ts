import {SET_INITIALIZED, SET_HUB_CONNECTION} from './constants';
import { Nullable } from '../../utils/types/Nullable';
import { HubConnection } from '@microsoft/signalr';
import * as actions from './actions';

export type InitializedAppState = {
    isInitialized: boolean,
    hubConnection: Nullable<HubConnection>
};

let initialState : InitializedAppState = {
    isInitialized: false,
    hubConnection: null
};

export type InitializedAppActions = ReturnType<typeof actions[keyof typeof actions]>;

const appReducer = (state = initialState, action : InitializedAppActions) : InitializedAppState => {
    switch (action.type) {
        case SET_INITIALIZED: {
            return {
                ...state, isInitialized: true
            };
        }
        case SET_HUB_CONNECTION: {
            return {
                ...state, hubConnection: action.payload
            }
        }
        default:
            return state;
    }
};

export default appReducer;