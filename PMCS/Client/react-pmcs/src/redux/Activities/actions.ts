import { IVaccine } from "../../common/models/IVaccine";
import { IWalking } from "../../common/models/IWalking";
import { IMeal } from "../../common/models/IMeal";
import { SET_IS_FETCHING, SET_VACCINES, SET_MEALS, SET_WALKINGS } from "./constants";

export type SetVaccinesAction = { type: typeof SET_VACCINES, payload: Array<IVaccine> };
export type SetMealsAction = { type: typeof SET_MEALS, payload: Array<IMeal> };
export type SetWalkingsAction = { type: typeof SET_WALKINGS, payload: Array<IWalking> };
export type SetIsFetchingAction = { type: typeof SET_IS_FETCHING, payload: boolean };

export const setVaccines = (pets: Array<IVaccine>): SetVaccinesAction => ({ type: SET_VACCINES, payload: pets });
export const setMeals = (pets: Array<IMeal>): SetMealsAction => ({ type: SET_MEALS, payload: pets });
export const setWalkings = (pets: Array<IWalking>): SetWalkingsAction => ({ type: SET_WALKINGS, payload: pets });
export const setisFetching = (isFetching: boolean): SetIsFetchingAction => ({ type: SET_IS_FETCHING, payload: isFetching });