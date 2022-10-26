import { IReminder } from "../../common/models/IReminder";
import { SET_IS_FETCHING, SET_REMINDERS } from "./constants";

export type SetRemindersAction = { type: typeof SET_REMINDERS, payload: Array<IReminder> };
export type SetIsFetchingAction = { type: typeof SET_IS_FETCHING, payload: boolean };

export const setReminders = (reminders: Array<IReminder>): SetRemindersAction => ({ type: SET_REMINDERS, payload: reminders });
export const setIsFetching = (isFetching: boolean): SetIsFetchingAction => ({ type: SET_IS_FETCHING, payload: isFetching });