import { IVaccine } from "../../common/models/IVaccine";
import { IWalking } from "../../common/models/IWalking";
import { IMeal } from "../../common/models/IMeal";
import { SET_IS_FETCHING, SET_VACCINES, SET_MEALS, SET_WALKINGS } from "./constants";

export type SetVaccinesAction = { type: typeof SET_VACCINES, payload: Array<IVaccine> };
export type SetMealsAction = { type: typeof SET_MEALS, payload: Array<IMeal> };
export type SetWalkingsAction = { type: typeof SET_WALKINGS, payload: Array<IWalking> };
export type SetIsFetchingAction = { type: typeof SET_IS_FETCHING, payload: boolean };

export const setVaccines = (vaccines: Array<IVaccine>): SetVaccinesAction => ({ type: SET_VACCINES, payload: vaccines });
export const setMeals = (meals: Array<IMeal>): SetMealsAction => ({ type: SET_MEALS, payload: meals });
export const setWalkings = (walkings: Array<IWalking>): SetWalkingsAction => ({ type: SET_WALKINGS, payload: walkings });
export const setIsFetching = (isFetching: boolean): SetIsFetchingAction => ({ type: SET_IS_FETCHING, payload: isFetching });