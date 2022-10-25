import { createSelector } from "reselect";

const selectOwner = (state) => state.profile.owner;
const selectErrors = (state) => state.profile.errors;

export const getOwner = createSelector(selectOwner, (owner) => {
    return owner;
});

export const getErrors = createSelector(selectErrors, (errors) => {
    return errors;
});
