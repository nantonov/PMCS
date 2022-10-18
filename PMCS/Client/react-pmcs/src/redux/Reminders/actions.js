import { SET_IS_FETCHING, SET_REMINDERS } from "./constants";

export const setReminders = (reminders) => ({ type: SET_REMINDERS, reminders: reminders });
export const setisFetching = (isFetching) => ({ type: SET_IS_FETCHING, isFetching: isFetching });