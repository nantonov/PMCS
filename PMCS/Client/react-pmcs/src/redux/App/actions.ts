import { SET_HUB_CONNECTION, SET_INITIALIZED } from "./constants";
import { HubConnection } from "@microsoft/signalr";
import { Nullable } from "../../utils/types/Nullable";

export type SetInitializedAction = {
    type: typeof SET_INITIALIZED
};

export type SetHubConnectionAction = {
    type: typeof SET_HUB_CONNECTION
    payload: Nullable<HubConnection>
}

export const setInitialized = (): SetInitializedAction => ({ type: SET_INITIALIZED });
export const setHubConnection = (connection: HubConnection): SetHubConnectionAction => ({ type: SET_HUB_CONNECTION, payload: connection });