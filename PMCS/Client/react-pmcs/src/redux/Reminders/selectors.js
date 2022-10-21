import { createSelector } from "reselect";
import { setRemindersDatesToLocalFormattedDate } from "../../utils/dateFormatitng";

const selectReminders = (state) => state.remindersPage.reminders;

const selectIsFetching = (state) => state.remindersPage.isFetching;

export const getReminders = createSelector(selectReminders, (reminders) => {
    return setRemindersDatesToLocalFormattedDate(reminders);
});

export const getIsFetching = createSelector(selectIsFetching, (isFetching) => {
    return isFetching;
})