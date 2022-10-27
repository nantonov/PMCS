import { SET_IS_FETCHING, SET_PETS } from "./constants";
import { IPet } from "../../common/models/IPet";

export type SetPetsAction = { type: typeof SET_PETS, payload: Array<IPet> };
export type SetIsFetchingAction = { type: typeof SET_IS_FETCHING, payload: boolean };

export const setPets = (pets: Array<IPet>): SetPetsAction => ({ type: SET_PETS, payload: pets });
export const setisFetching = (isFetching: boolean): SetIsFetchingAction => ({ type: SET_IS_FETCHING, payload: isFetching });