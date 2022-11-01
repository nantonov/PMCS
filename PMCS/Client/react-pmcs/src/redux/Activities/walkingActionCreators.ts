import { ActivitiesActions } from "./activitiesReducer";
import { setIsFetching, setWalkings } from "./actions";
import activityService from "../../Services/activityService";
import { AppDispatch } from "../types";
import { ICreateActivityRequest } from "../../common/requests/Activities/ICreateActivityRequest";
import { stopSubmit, startSubmit, reset } from "redux-form";
import { ADD_FORM, EDIT_FORM } from "./constants";
import { IUpdateActivityRequest } from "../../common/requests/Activities/IUpdateActivityRequest";
import { createErrorsListForActivities } from "../../utils/createErrorsList";

export const fetchWalkings = () => {
    return async (dispatch: AppDispatch<ActivitiesActions>) => {
        dispatch(setIsFetching(true));
        await activityService.getAll("Walking").then((walkings) => {
            dispatch(setWalkings(walkings));
            dispatch(setIsFetching(false));
        });
    };
};

export const createWalkings = (walking: ICreateActivityRequest) => {
    return async (dispatch: AppDispatch<ActivitiesActions>) => {
        const result = await activityService.create("Walking", walking);

        if (result.status === 400) {
            const errors = createErrorsListForActivities(result);
            dispatch(stopSubmit(ADD_FORM, { _error: errors[0] }));
            console.log(result);
        } else {
            startSubmit(ADD_FORM);
            dispatch(reset(ADD_FORM));
            dispatch(fetchWalkings());
        }
    };
};

export const editWalking = (walking: IUpdateActivityRequest) => {
    return async (dispatch: AppDispatch<ActivitiesActions>) => {
        const result = await activityService.update("Walking", walking);
        if (result.status === 400) {
            const errors = createErrorsListForActivities(result);
            dispatch(stopSubmit(EDIT_FORM, { _error: errors[0] }));
            console.log(result);
        } else {
            startSubmit(EDIT_FORM);
            dispatch(fetchWalkings());
        }
    };
};

export const deleteWalking = (walkingId: number) => {
    return async (dispatch: AppDispatch<ActivitiesActions>) => {
        const result = await activityService.delete("Walking", walkingId);
        if (result) dispatch(fetchWalkings());
    };
};