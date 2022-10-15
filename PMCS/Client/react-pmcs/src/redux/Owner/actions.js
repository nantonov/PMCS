import { SET_OWNER, SET_ERRORS } from "./constants";

export const setOwner = (owner) => ({ type: SET_OWNER, owner: owner });
export const setErrors = (errors) => ({ type: SET_ERRORS, errors: errors });