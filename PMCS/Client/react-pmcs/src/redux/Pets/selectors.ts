import { createSelector } from "reselect";
import { IPet } from "../../common/models/IPet";
import { setPetDatesToLocalFormattedDate } from "../../utils/dateFormatitng";
import { RootState } from "../types";

const selectPets = (state: RootState) => state.petsPage.pets;

const selectIsFetching = (state: RootState) => state.petsPage.isFetching;

export const getPets = createSelector(selectPets, (pets: Array<IPet>) => {
    return setPetDatesToLocalFormattedDate(pets);
});

export const isFetching = createSelector(selectIsFetching, (isFetching: boolean) => {
    return isFetching;
})