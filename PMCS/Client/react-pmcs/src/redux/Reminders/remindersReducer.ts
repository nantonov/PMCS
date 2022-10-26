import { IReminder } from "../../common/models/IReminder";
import { SET_IS_FETCHING, SET_REMINDERS } from "./constants";
import * as actions from './actions';

export type RemindersState = {
    reminders: Array<IReminder>,
    isFetching: boolean
};

let initialState: RemindersState = {
    reminders: [],
    isFetching: false,
};

export type RemindersActions = ReturnType<typeof actions[keyof typeof actions]>;

const remindersReducer = (state = initialState, action: RemindersActions): RemindersState => {
    switch (action.type) {
        case SET_REMINDERS: {
            return { ...state, reminders: action.payload }
        }
        case SET_IS_FETCHING: {
            return { ...state, isFetching: action.payload }
        }
        default:
            return state;
    }
}

export default remindersReducer;