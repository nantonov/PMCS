import { createSelector } from "reselect";
import { IReminder } from "../../common/models/IReminder";
import { setRemindersDatesToLocalFormattedDate } from "../../utils/dateFormatitng";
import { RootState } from "../types";

const selectReminders = (state: RootState) => state.remindersPage.reminders;

const selectIsFetching = (state: RootState) => state.remindersPage.isFetching;

export const getReminders = createSelector(selectReminders, (reminders: Array<IReminder>) => {
    return setRemindersDatesToLocalFormattedDate(reminders);
});

export const getIsFetching = createSelector(selectIsFetching, (isFetching: boolean) => {
    return isFetching;
})