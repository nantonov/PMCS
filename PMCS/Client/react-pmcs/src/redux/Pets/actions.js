import { SET_IS_FETCHING, SET_PETS, SET_ERRORS } from "./constants";

export const setPets = (pets) => ({ type: SET_PETS, pets: pets });
export const setisFetching = (isFetching) => ({ type: SET_IS_FETCHING, isFetching: isFetching });
export const setErrors = (errors) => ({ type: SET_ERRORS, errors: errors });