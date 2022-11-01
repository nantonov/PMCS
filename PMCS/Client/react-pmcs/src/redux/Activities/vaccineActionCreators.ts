import { AppDispatch } from "../types";
import activityService from "../../Services/activityService";
import { ActivitiesActions } from "./activitiesReducer";
import { setIsFetching, setVaccines } from "./actions";
import { ICreateActivityRequest } from "../../common/requests/Activities/ICreateActivityRequest";
import { IUpdateActivityRequest } from "../../common/requests/Activities/IUpdateActivityRequest";
import { stopSubmit, startSubmit, reset } from "redux-form";
import { ADD_FORM, EDIT_FORM } from "./constants";
import { createErrorsListForActivities } from "../../utils/createErrorsList";

export const fetchVaccines = () => {
    return async (dispatch: AppDispatch<ActivitiesActions>) => {
        dispatch(setIsFetching(true));
        await activityService.getAll("Vaccine").then((vaccines) => {
            dispatch(setVaccines(vaccines));
            dispatch(setIsFetching(false));
        });
    };
};

export const createMeal = (vaccine: ICreateActivityRequest) => {
    return async (dispatch: AppDispatch<ActivitiesActions>) => {
        const result = await activityService.create("Vaccine", vaccine);

        if (result.status === 400) {
            const errors = createErrorsListForActivities(result);
            dispatch(stopSubmit(ADD_FORM, { _error: errors[0] }));
            console.log(result);
        } else {
            startSubmit(ADD_FORM);
            dispatch(reset(ADD_FORM));
            dispatch(fetchVaccines());
        }
    };
};

export const editMeal = (meal: IUpdateActivityRequest) => {
    return async (dispatch: AppDispatch<ActivitiesActions>) => {
        const result = await activityService.update("Vaccine", meal);
        if (result.status === 400) {
            const errors = createErrorsListForActivities(result);
            dispatch(stopSubmit(EDIT_FORM, { _error: errors[0] }));
            console.log(result);
        } else {
            startSubmit(EDIT_FORM);
            dispatch(fetchVaccines());
        }
    };
};

export const deleteVaccine = (vaccineId: number) => {
    return async (dispatch: AppDispatch<ActivitiesActions>) => {
        const result = await activityService.delete("Vaccine", vaccineId);
        if (result) dispatch(fetchVaccines());
    };
};