import { setReminders, setIsFetching } from "./actions";
import remindersService from "../../Services/remindersService";
import { stopSubmit, reset, startSubmit } from "redux-form";
import { ADD_FORM, EDIT_FORM } from "./constants";
import { createErrorsListForReminders } from "../../utils/createErrorsList";
import { AppDispatch } from "../types";
import { RemindersActions } from "./remindersReducer";
import { IReminder } from "../../common/models/IReminder";

export const fetchReminders = () => {
    return async (dispatch: AppDispatch<RemindersActions>) => {
        dispatch(setIsFetching(true));
        await remindersService.getAll().then((reminders) => {
            dispatch(setReminders(reminders));
            dispatch(setIsFetching(false));
        });
    };
};

export const createReminder = (reminder: IReminder) => {
    return async (dispatch: AppDispatch<RemindersActions>) => {
        const result = await remindersService.create(reminder);
        if (result.status === 400) {
            const errors = createErrorsListForReminders(result);
            dispatch(stopSubmit(ADD_FORM, { _error: errors[0] }));
            console.log(result);
        } else {
            startSubmit(ADD_FORM);
            dispatch(reset(ADD_FORM));
            dispatch(fetchReminders());
        }
    };
};

export const editReminder = (reminder: IReminder) => {
    return async (dispatch: AppDispatch<RemindersActions>) => {
        const result = await remindersService.update(reminder);
        if (result.status === 400) {
            const errors = createErrorsListForReminders(result);
            dispatch(stopSubmit(EDIT_FORM, { _error: errors[0] }));
            console.log(result);
        } else {
            startSubmit(EDIT_FORM);
            dispatch(fetchReminders());
        }
    };
};

export const deleteReminder = (reminderId: number) => {
    return async (dispatch: AppDispatch<RemindersActions>) => {
        const result = await remindersService.delete(reminderId);
        if (result) dispatch(fetchReminders());
    };
};

export const setReminderStatusAsDone = (reminderId: number) => {
    return async (dispatch: AppDispatch<RemindersActions>) => {
        const result = await remindersService.setReminderStatusDone(reminderId);
        if (result.status === 400) {
            console.log(result);
        } else {
            dispatch(fetchReminders());
        }
    };
};