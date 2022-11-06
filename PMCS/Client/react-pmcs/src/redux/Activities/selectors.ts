import { createSelector } from "reselect";
import { IMeal } from "../../common/models/IMeal";
import { IVaccine } from "../../common/models/IVaccine";
import { IWalking } from "../../common/models/IWalking";
import { RootState } from "../types";
import { setMealDatesToLocalFormattedDate, setVaccineDatesToLocalFormattedDate, setWalkingDatesToLocalFormattedDate } from "../../utils/dateFormatitng";

const selectMeals = (state: RootState) => state.activitiesPage.meals;
const selectWalkings = (state: RootState) => state.activitiesPage.walkings;
const selectVaccines = (state: RootState) => state.activitiesPage.vaccines;
const selectIsFetching = (state: RootState) => state.activitiesPage.isFetching;

export const getMeals = createSelector(selectMeals, (meals: Array<IMeal>) => {
    return setMealDatesToLocalFormattedDate(meals);
});

export const getWalkings = createSelector(selectWalkings, (walkings: Array<IWalking>) => {
    return setWalkingDatesToLocalFormattedDate(walkings);
});

export const getVaccines = createSelector(selectVaccines, (vaccines: Array<IVaccine>) => {
    return setVaccineDatesToLocalFormattedDate(vaccines);
});

export const isFetching = createSelector(selectIsFetching, (isFetching: boolean) => {
    return isFetching;
})