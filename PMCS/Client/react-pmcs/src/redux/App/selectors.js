import { createSelector } from "reselect";

const selectHubConnection = (state) => state.app.hubConnection;
const selectIsInitialized = (state) => state.app.isInitialized;

export const getHubConnection = createSelector(selectHubConnection, (connection) => {
    return connection;
});

export const getIsInitialized = createSelector(selectIsInitialized, (isInitialized) => {
    return isInitialized;
});