import { createSelector } from "reselect";
import { setPetDatesToLocalFormattedDate } from "../../utils/dateFormatitng";

const selectPets = (state) => state.petsPage.pets;

const selectIsFetching = (state) => state.petsPage.isFetching;

export const getPets = createSelector(selectPets, (pets) => {
    return setPetDatesToLocalFormattedDate(pets);
});

export const getIsFetching = createSelector(selectIsFetching, (isFetching) => {
    return isFetching;
})