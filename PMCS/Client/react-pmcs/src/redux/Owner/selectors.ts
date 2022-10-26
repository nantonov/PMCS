import { createSelector } from "reselect";
import { IOwner } from "../../common/models/IOwner";
import { Nullable } from "../../utils/types/Nullable";
import { RootState } from "../types";

const selectOwner = (state : RootState) : Nullable<IOwner> => state.profile.owner;
const selectErrors = (state : RootState) : Array<String> => state.profile.errors;

export const getOwner = createSelector(selectOwner, (owner : Nullable<IOwner>) => {
    return owner;
});

export const getErrors = createSelector(selectErrors, (errors : Array<String>) => {
    return errors;
});
