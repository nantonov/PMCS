import { IOwner } from "../../common/models/IOwner";
import { SET_OWNER, SET_ERRORS } from "./constants";

export type SetOwnerAction = {
    type: typeof SET_OWNER
    payload: IOwner
};

export type SetErrorsAction = {
    type: typeof SET_ERRORS
    payload:  Array<String>
}

export const setOwner = (owner : IOwner) : SetOwnerAction => ({ type: SET_OWNER, payload: owner });
export const setErrors = (errors :  Array<String>) : SetErrorsAction => ({ type: SET_ERRORS, payload: errors });