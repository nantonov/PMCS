import { setReminders, setisFetching } from "./actions";
import remindersService from "../../Services/remindersService";
import { stopSubmit } from "redux-form";
import { ADD_FORM, EDIT_FORM } from "./constants";
import { createErrorsListForReminders } from "../../utils/createErrorsList";

export const fetchReminders = () => {
    return async (dispatch) => {
        dispatch(setisFetching(true));
        await remindersService.getAll().then((reminders) => {
            dispatch(setReminders(reminders));
            dispatch(setisFetching(false));
        });
    };
};

export const createReminder = (reminder) => {
    return async (dispatch) => {
        const result = await remindersService.create(reminder);
        if (result.status === 400) {
            const errors = createErrorsListForReminders(result);
            dispatch(stopSubmit(ADD_FORM, { _error: errors[0] }));
            console.log(result);
        } else {
            dispatch(fetchReminders());
        }
    };
};

export const editReminder = (reminder) => {
    return async (dispatch) => {
        const result = await remindersService.update(reminder);
        if (result.status === 400) {
            console.log(result);
        } else {
            dispatch(fetchReminders());
        }
    };
};

export const deleteReminder = (reminderId) => {
    return async (dispatch) => {
        const result = await remindersService.delete(reminderId);
        if (result) dispatch(fetchReminders());
    };
};

export const setReminderStatusAsDone = (reminderId) => {
    return async (dispatch) => {
        const result = await remindersService.setReminderStatusDone(reminderId);
        if (result.status === 400) {
            console.log(result);
        } else {
            dispatch(fetchReminders());
        }
    };
};

export const resetReminderStatus = (reminderId) => {
    return async (dispatch) => {
        const result = await remindersService.resetReminderStatus(reminderId);
        if (result.status === 400) {
            console.log(result);
        } else {
            dispatch(fetchReminders());
        }
    };
};
