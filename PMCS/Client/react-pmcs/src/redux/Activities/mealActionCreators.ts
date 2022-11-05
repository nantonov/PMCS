import { AppDispatch } from "../types";
import activityService from "../../Services/activityService";
import { ActivitiesActions } from "./activitiesReducer";
import { setIsFetching, setMeals } from "./actions";
import { ICreateActivityRequest } from "../../common/requests/Activities/ICreateActivityRequest";
import { IUpdateActivityRequest } from "../../common/requests/Activities/IUpdateActivityRequest";
import { stopSubmit, startSubmit, reset } from "redux-form";
import { ADD_FORM, EDIT_FORM } from "./constants";
import { createErrorsListForActivities } from "../../utils/createErrorsList";

export const fetchMeals = () => {
    return async (dispatch: AppDispatch<ActivitiesActions>) => {
        dispatch(setIsFetching(true));
        await activityService.getAll("Meal").then((meals) => {
            dispatch(setMeals(meals));
            dispatch(setIsFetching(false));
        });
    };
};

export const createMeal = (meal: ICreateActivityRequest) => {
    return async (dispatch: AppDispatch<ActivitiesActions>) => {
        const result = await activityService.create("Meal", meal);

        if (result.status === 400) {
            const errors = createErrorsListForActivities(result);
            dispatch(stopSubmit(ADD_FORM, { _error: errors[0] }));
            console.log(result);
        } else {
            startSubmit(ADD_FORM);
            dispatch(fetchMeals());
        }
    };
};

export const editMeal = (meal: IUpdateActivityRequest) => {
    return async (dispatch: AppDispatch<ActivitiesActions>) => {
        const result = await activityService.update("Meal", meal);
        if (result.status === 400) {
            const errors = createErrorsListForActivities(result);
            dispatch(stopSubmit(EDIT_FORM, { _error: errors[0] }));
            console.log(result);
        } else {
            startSubmit(EDIT_FORM);
            dispatch(fetchMeals());
        }
    };
};

export const deleteMeal = (mealId: number) => {
    return async (dispatch: AppDispatch<ActivitiesActions>) => {
        const result = await activityService.delete("Meal", mealId);
        if (result) dispatch(fetchMeals());
    };
};