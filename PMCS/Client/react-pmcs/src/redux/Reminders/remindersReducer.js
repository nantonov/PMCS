import { SET_IS_FETCHING, SET_REMINDERS } from "./constants";

let initialState = {
    reminders: [],
    isFetching: false,
};

const remindersReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_REMINDERS: {
            return { ...state, reminders: action.reminders }
        }
        case SET_IS_FETCHING: {
            return { ...state, isFetching: action.isFetching }
        }
        default:
            return state;
    }
}

export default remindersReducer;