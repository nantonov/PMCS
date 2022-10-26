import { HubConnection } from "@microsoft/signalr";
import { createSelector } from "reselect";
import { Nullable } from "../../utils/types/Nullable";
import { RootState } from "../types";

const selectHubConnection = (state : RootState) : Nullable<HubConnection> => state.app.hubConnection;
const selectIsInitialized = (state : RootState) : boolean => state.app.isInitialized;

export const getHubConnection = createSelector(selectHubConnection, (connection) => {
    return connection;
});

export const getIsInitialized = createSelector(selectIsInitialized, (isInitialized) => {
    return isInitialized;
});